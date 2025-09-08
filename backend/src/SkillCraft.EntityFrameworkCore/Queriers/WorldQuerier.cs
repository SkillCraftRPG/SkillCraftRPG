using Krakenar.Contracts.Search;
using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.EntityFrameworkCore.Entities;

namespace SkillCraft.EntityFrameworkCore.Queriers;

internal class WorldQuerier : IWorldQuerier
{
  private readonly DbSet<WorldEntity> _worlds;

  public WorldQuerier(SkillCraftContext context)
  {
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

    return null; // TODO(fpion): implement
  }

  public Task<SearchResults<WorldModel>> SearchAsync(SearchWorldsPayload payload, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }
}
