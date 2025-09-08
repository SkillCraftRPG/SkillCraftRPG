namespace SkillCraft.Core.Worlds;

public interface IWorldRepository
{
  Task<World?> LoadAsync(WorldId worldId, CancellationToken cancellationToken = default);

  Task SaveAsync(World world, CancellationToken cancellationToken = default);
  Task SaveAsync(IEnumerable<World> worlds, CancellationToken cancellationToken = default);
}
