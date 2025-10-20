using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds;

public interface IWorldQuerier
{
  Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(WorldId worldId, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(Guid entityId, CancellationToken cancellationToken = default);
}
