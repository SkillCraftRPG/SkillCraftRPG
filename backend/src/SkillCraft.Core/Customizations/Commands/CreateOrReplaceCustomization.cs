using FluentValidation;
using Logitar.EventSourcing;
using SkillCraft.Core.Customizations.Models;
using SkillCraft.Core.Customizations.Validators;
using SkillCraft.Core.Permissions;

namespace SkillCraft.Core.Customizations.Commands;

internal record CreateOrReplaceCustomizationCommand(CreateOrReplaceCustomizationPayload Payload, Guid? Id) : ICommand<CreateOrReplaceCustomizationResult>;

/// <exception cref="PermissionDeniedException"></exception>
/// <exception cref="ValidationException"></exception>
internal class CreateOrReplaceCustomizationCommandHandler : ICommandHandler<CreateOrReplaceCustomizationCommand, CreateOrReplaceCustomizationResult>
{
  private readonly IApplicationContext _applicationContext;
  private readonly IPermissionService _permissionService;
  private readonly ICustomizationManager _customizationManager;
  private readonly ICustomizationQuerier _customizationQuerier;
  private readonly ICustomizationRepository _customizationRepository;

  public CreateOrReplaceCustomizationCommandHandler(
    IApplicationContext applicationContext,
    IPermissionService permissionService,
    ICustomizationManager customizationManager,
    ICustomizationQuerier customizationQuerier,
    ICustomizationRepository customizationRepository)
  {
    _applicationContext = applicationContext;
    _permissionService = permissionService;
    _customizationManager = customizationManager;
    _customizationQuerier = customizationQuerier;
    _customizationRepository = customizationRepository;
  }

  public async Task<CreateOrReplaceCustomizationResult> HandleAsync(CreateOrReplaceCustomizationCommand command, CancellationToken cancellationToken)
  {
    CreateOrReplaceCustomizationPayload payload = command.Payload;
    new CreateOrReplaceCustomizationValidator().ValidateAndThrow(payload);

    CustomizationId customizationId = CustomizationId.NewId(_applicationContext.WorldId);
    Customization? customization = null;
    if (command.Id.HasValue)
    {
      customizationId = new CustomizationId(customizationId.WorldId, command.Id.Value);
      customization = await _customizationRepository.LoadAsync(customizationId, cancellationToken);
    }

    Name name = new(payload.Name);
    ActorId? actorId = _applicationContext.ActorId;

    bool created = false;
    if (customization is null)
    {
      //await _permissionService.CheckCreateCustomizationAsync(cancellationToken); // TODO(fpion): implement

      customization = new Customization(name, actorId, customizationId);
      created = true;
    }
    else
    {
      await _permissionService.CheckAsync(ActionKind.Update, customization, cancellationToken);

      customization.Name = name;
    }

    customization.Description = Description.TryCreate(payload.Description);

    customization.Update(actorId);
    await _customizationManager.SaveAsync(customization, cancellationToken);

    CustomizationModel model = await _customizationQuerier.ReadAsync(customization, cancellationToken);
    return new CreateOrReplaceCustomizationResult(model, created);
  }
}
