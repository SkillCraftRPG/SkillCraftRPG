using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;
using SkillCraft.EntityFrameworkCore.Handlers;
using SkillCraft.EntityFrameworkCore.Queriers;
using SkillCraft.EntityFrameworkCore.Repositories;

namespace SkillCraft.EntityFrameworkCore;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftEntityFrameworkCore(this IServiceCollection services)
  {
    return services
      .AddSkillCraftHandlers()
      .AddSkillCraftQueriers()
      .AddSkillCraftRepositories();
  }

  private static IServiceCollection AddSkillCraftHandlers(this IServiceCollection services)
  {
    WorldEvents.Register(services);
    return services;
  }

  private static IServiceCollection AddSkillCraftQueriers(this IServiceCollection services)
  {
    return services.AddScoped<IWorldQuerier, WorldQuerier>();
  }

  private static IServiceCollection AddSkillCraftRepositories(this IServiceCollection services)
  {
    return services.AddScoped<IWorldRepository, WorldRepository>();
  }
}
