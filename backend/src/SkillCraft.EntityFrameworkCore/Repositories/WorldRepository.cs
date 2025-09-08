using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.EntityFrameworkCore.Repositories;

internal class WorldRepository : Repository, IWorldRepository
{
  public WorldRepository(IEventStore eventStore) : base(eventStore)
  {
  }

  public async Task<World?> LoadAsync(WorldId worldId, CancellationToken cancellationToken)
  {
    return await base.LoadAsync<World>(worldId.StreamId, cancellationToken);
  }

  public async Task SaveAsync(World world, CancellationToken cancellationToken)
  {
    await base.SaveAsync(world, cancellationToken);
  }
  public async Task SaveAsync(IEnumerable<World> worlds, CancellationToken cancellationToken)
  {
    await base.SaveAsync(worlds, cancellationToken);
  }
}
