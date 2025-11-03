using Microsoft.EntityFrameworkCore;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure;

public class GameContext : DbContext
{
  internal const string Schema = "Game";

  public GameContext(DbContextOptions<GameContext> options) : base(options)
  {
  }

  internal DbSet<WorldEntity> Worlds => Set<WorldEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
