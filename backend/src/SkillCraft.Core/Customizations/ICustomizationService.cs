using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Customizations.Commands;
using SkillCraft.Core.Customizations.Models;

namespace SkillCraft.Core.Customizations;

public interface ICustomizationService
{
  Task<CreateOrReplaceCustomizationResult> CreateOrReplaceAsync(CreateOrReplaceCustomizationPayload payload, Guid? id = null, CancellationToken cancellationToken = default);
}

internal class CustomizationService : ICustomizationService
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<ICustomizationService, CustomizationService>();
    services.AddTransient<ICustomizationManager, CustomizationManager>();
    services.AddTransient<ICommandHandler<CreateOrReplaceCustomizationCommand, CreateOrReplaceCustomizationResult>, CreateOrReplaceCustomizationCommandHandler>();
  }

  private readonly ICommandBus _commandBus;

  public CustomizationService(ICommandBus commandBus)
  {
    _commandBus = commandBus;
  }

  public async Task<CreateOrReplaceCustomizationResult> CreateOrReplaceAsync(CreateOrReplaceCustomizationPayload payload, Guid? id, CancellationToken cancellationToken)
  {
    CreateOrReplaceCustomizationCommand command = new(payload, id);
    return await _commandBus.ExecuteAsync(command, cancellationToken);
  }
}
