using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.EntityFrameworkCore.SqlServer;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCoreSqlServer(this IServiceCollection services, IConfiguration configuration)
  {
    string? connectionString = EnvironmentHelper.TryGetString("SQLCONNSTR_SkillCraft") ?? configuration.GetConnectionString("SqlServer");
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentException("The connection string for the database provider 'SqlServer' could not be found.", nameof(configuration));
    }

    return services
      .AddDbContext<SkillCraftContext>(options => options.UseSqlServer(
        connectionString,
        options => options.MigrationsAssembly("SkillCraft.EntityFrameworkCore.SqlServer")));
  }
}
