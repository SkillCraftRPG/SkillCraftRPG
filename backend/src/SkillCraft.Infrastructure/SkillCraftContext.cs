using Microsoft.EntityFrameworkCore;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure;

public class SkillCraftContext : DbContext
{
  public SkillCraftContext(DbContextOptions<SkillCraftContext> options) : base(options)
  {
  }

  internal DbSet<CustomizationEntity> Customizations => Set<CustomizationEntity>();
  internal DbSet<WorldEntity> Worlds => Set<WorldEntity>();

  internal async Task<WorldEntity> LoadWorldAsync(WorldId id, CancellationToken cancellationToken)
  {
    return await Worlds.SingleOrDefaultAsync(x => x.StreamId == id.Value, cancellationToken)
      ?? throw new InvalidOperationException($"The world 'StreamId={id}' entity was not found.");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
