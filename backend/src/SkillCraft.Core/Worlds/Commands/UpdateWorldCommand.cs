using FluentValidation;
using Krakenar.Core;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Core.Worlds.Validators;

namespace SkillCraft.Core.Worlds.Commands;

public record UpdateWorldCommand(Guid Id, UpdateWorldPayload Payload) : ICommand<WorldModel?>;

/// <exception cref="ValidationException"></exception>
internal class UpdateWorldCommandHandler : ICommandHandler<UpdateWorldCommand, WorldModel?>
{
  private readonly IApplicationContext _applicationContext;
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public UpdateWorldCommandHandler(IApplicationContext applicationContext, IWorldQuerier worldQuerier, IWorldRepository worldRepository)
  {
    _applicationContext = applicationContext;
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task<WorldModel?> HandleAsync(UpdateWorldCommand command, CancellationToken cancellationToken)
  {
    UpdateWorldPayload payload = command.Payload;
    new UpdateWorldValidator().ValidateAndThrow(payload);

    WorldId worldId = new(command.Id);
    World? world = await _worldRepository.LoadAsync(worldId, cancellationToken);
    if (world is null)
    {
      return null;
    }

    if (!string.IsNullOrWhiteSpace(payload.Name))
    {
      world.Name = new DisplayName(payload.Name);
    }
    if (payload.Description is not null)
    {
      world.Description = Description.TryCreate(payload.Description.Value);
    }

    world.Update(_applicationContext.ActorId);

    await _worldRepository.SaveAsync(world, cancellationToken);

    return await _worldQuerier.ReadAsync(world, cancellationToken);
  }

  // TODO(fpion): Authorization
  // TODO(fpion): Storage
}
