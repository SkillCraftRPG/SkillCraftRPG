using FluentValidation;
using SkillCraft.Core.Customizations.Models;
using SkillCraft.Core.Customizations.Validators;
using SkillCraft.Core.Permissions;
using SkillCraft.Core.Worlds;

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

    UserId userId = _applicationContext.UserId;
    WorldId worldId = _applicationContext.WorldId;

    CustomizationId customizationId = CustomizationId.NewId(_applicationContext.WorldId);
    Customization? customization = null;
    if (command.Id.HasValue)
    {
      customizationId = new CustomizationId(customizationId.WorldId, command.Id.Value);
      customization = await _customizationRepository.LoadAsync(customizationId, cancellationToken);
    }

    Name name = new(payload.Name);

    bool created = false;
    if (customization is null)
    {
      await _permissionService.CheckAsync("CreateCustomization", worldId, cancellationToken);

      customization = new Customization(payload.Kind, name, userId, customizationId);
      created = true;
    }
    else
    {
      await _permissionService.CheckAsync(ActionKind.Update, customization, cancellationToken);

      customization.Name = name;
    }

    customization.Description = Description.TryCreate(payload.Description);

    customization.Update(userId);
    await _customizationManager.SaveAsync(customization, cancellationToken);

    CustomizationModel model = await _customizationQuerier.ReadAsync(customization, cancellationToken);
    return new CreateOrReplaceCustomizationResult(model, created);
  }
}
