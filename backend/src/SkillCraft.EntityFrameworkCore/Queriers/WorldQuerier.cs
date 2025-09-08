using Krakenar.Contracts.Actors;
using Krakenar.Contracts.Search;
using Krakenar.Core.Actors;
using Logitar.EventSourcing;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.EntityFrameworkCore.Entities;

namespace SkillCraft.EntityFrameworkCore.Queriers;

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
    return await ReadAsync(world.Id, cancellationToken)
      ?? throw new InvalidOperationException($"The world entity 'StreamId={world.Id}' was not found.");
  }
  public async Task<WorldModel?> ReadAsync(WorldId worldId, CancellationToken cancellationToken)
  {
    return await ReadAsync(worldId.ToGuid(), cancellationToken);
  }
  public async Task<WorldModel?> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _worlds.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    return world is null ? null : await MapAsync(world, cancellationToken);
  }

  public Task<SearchResults<WorldModel>> SearchAsync(SearchWorldsPayload payload, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }

  private async Task<WorldModel> MapAsync(WorldEntity world, CancellationToken cancellationToken)
  {
    return (await MapAsync([world], cancellationToken)).Single();
  }
  private async Task<IReadOnlyCollection<WorldModel>> MapAsync(IEnumerable<WorldEntity> worlds, CancellationToken cancellationToken)
  {
    IEnumerable<ActorId> actorIds = worlds.SelectMany(world => world.GetActorIds());
    IReadOnlyDictionary<ActorId, Actor> actors = await _actorService.FindAsync(actorIds, cancellationToken);
    Mapper mapper = new(actors);

    return worlds.Select(mapper.ToWorld).ToList().AsReadOnly();
  }
}
