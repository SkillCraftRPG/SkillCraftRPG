using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Models;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Queriers;

internal class WorldQuerier : IWorldQuerier
{
  private readonly IActorService _actorService;
  private readonly DbSet<WorldEntity> _worlds;

  public WorldQuerier(IActorService actorService, SkillCraftContext context)
  {
    _actorService = actorService;
    _worlds = context.Worlds;
  }

  public async Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken)
  {
    return await ReadAsync(world.Id, cancellationToken) ?? throw new InvalidOperationException($"The world entity 'StreamId={world.Id}' was not found.");
  }
  public async Task<WorldModel?> ReadAsync(WorldId worldId, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.StreamId == worldId.Value) // TODO(fpion): access
      .SingleOrDefaultAsync(cancellationToken);

    return world is null ? null : await MapAsync(world, cancellationToken);
  }
  public async Task<WorldModel?> ReadAsync(Guid entityId, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _worlds.AsNoTracking()
      .Where(x => x.EntityId == entityId) // TODO(fpion): access
      .SingleOrDefaultAsync(cancellationToken);

    return world is null ? null : await MapAsync(world, cancellationToken);
  }

  private async Task<WorldModel> MapAsync(WorldEntity world, CancellationToken cancellationToken)
  {
    return (await MapAsync([world], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<WorldModel>> MapAsync(IEnumerable<WorldEntity> worlds, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = worlds.SelectMany(world => world.GetActorIds());
    IReadOnlyDictionary<ActorId, ActorModel> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    Mapper mapper = new(actors);

    return worlds.Select(mapper.ToWorld).ToList().AsReadOnly();
  }
}
