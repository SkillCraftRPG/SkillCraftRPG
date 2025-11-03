using Logitar.EventSourcing.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Infrastructure.PostgreSQL;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_Krakenar");
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      connectionString = configuration.GetConnectionString("PostgreSQL");
    }
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException("The PostgreSQL connection string was not found.", nameof(configuration));
    }
    return services.AddSkillCraftInfrastructurePostgreSQL(connectionString);
  }
  public static IServiceCollection AddSkillCraftInfrastructurePostgreSQL(this IServiceCollection services, string connectionString)
  {
    return services
      .AddLogitarEventSourcingWithEntityFrameworkCorePostgreSQL(connectionString)
      .AddDbContext<GameContext>(options => options.UseNpgsql(connectionString, options => options.MigrationsAssembly("SkillCraft.Infrastructure.PostgreSQL")))
      .AddSingleton<ISqlHelper, PostgresHelper>();
  }
}
