using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds.Queries;

internal record ReadWorldQuery(Guid Id) : IQuery<WorldModel?>;

internal class ReadWorldQueryHandler : IQueryHandler<ReadWorldQuery, WorldModel?>
{
  private readonly IWorldQuerier _worldQuerier;

  public ReadWorldQueryHandler(IWorldQuerier worldQuerier)
  {
    _worldQuerier = worldQuerier;
  }

  public async Task<WorldModel?> HandleAsync(ReadWorldQuery query, CancellationToken cancellationToken)
  {
    return await _worldQuerier.ReadAsync(query.Id, cancellationToken);
  }
}
