using FluentValidation;
using Krakenar.Core;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Core.Worlds.Validators;

namespace SkillCraft.Core.Worlds.Commands;

public record CreateOrReplaceWorldCommand(CreateOrReplaceWorldPayload Payload, Guid? Id) : ICommand<CreateOrReplaceWorldResult>;

/// <exception cref="ValidationException"></exception>
internal class CreateOrReplaceWorldCommandHandler : ICommandHandler<CreateOrReplaceWorldCommand, CreateOrReplaceWorldResult>
{
  private readonly IApplicationContext _applicationContext;
  private readonly IWorldQuerier _worldQuerier;
  private readonly IWorldRepository _worldRepository;

  public CreateOrReplaceWorldCommandHandler(IApplicationContext applicationContext, IWorldQuerier worldQuerier, IWorldRepository worldRepository)
  {
    _applicationContext = applicationContext;
    _worldQuerier = worldQuerier;
    _worldRepository = worldRepository;
  }

  public async Task<CreateOrReplaceWorldResult> HandleAsync(CreateOrReplaceWorldCommand command, CancellationToken cancellationToken)
  {
    CreateOrReplaceWorldPayload payload = command.Payload;
    new CreateOrReplaceWorldValidator().ValidateAndThrow(payload);

    WorldId worldId = WorldId.NewId();
    World? world = null;
    if (command.Id.HasValue)
    {
      worldId = new(command.Id.Value);
      world = await _worldRepository.LoadAsync(worldId, cancellationToken);
    }

    ActorId? actorId = _applicationContext.ActorId;
    DisplayName name = new(payload.Name);

    bool created = false;
    if (world is null)
    {
      world = new(name, actorId, worldId);
      created = true;
    }
    else
    {
      world.Name = name;
    }

    world.Description = Description.TryCreate(payload.Description);

    world.Update(actorId);

    await _worldRepository.SaveAsync(world, cancellationToken);

    WorldModel model = await _worldQuerier.ReadAsync(world, cancellationToken);
    return new CreateOrReplaceWorldResult(model, created);
  }

  // TODO(fpion): Authorization
  // TODO(fpion): Storage
}
