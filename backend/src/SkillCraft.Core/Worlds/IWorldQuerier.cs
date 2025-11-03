using Krakenar.Contracts.Search;
using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds;

public interface IWorldQuerier
{
  Task<WorldModel> ReadAsync(World world, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(WorldId id, CancellationToken cancellationToken = default);
  Task<WorldModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);

  Task<SearchResults<WorldModel>> SearchAsync(SearchWorldsPayload payload, CancellationToken cancellationToken = default);
}
