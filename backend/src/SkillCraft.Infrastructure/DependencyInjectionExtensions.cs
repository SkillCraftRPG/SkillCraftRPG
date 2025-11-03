using Logitar.EventSourcing.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Caching;
using SkillCraft.Core.Worlds;
using SkillCraft.Infrastructure.Actors;
using SkillCraft.Infrastructure.Caching;
using SkillCraft.Infrastructure.Handlers;
using SkillCraft.Infrastructure.Queriers;
using SkillCraft.Infrastructure.Repositories;
using SkillCraft.Infrastructure.Settings;

namespace SkillCraft.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services)
  {
    return services
      .AddEventHandlers()
      .AddQueriers()
      .AddRepositories()
      .AddSingleton(InitializeCachingSettings)
      .AddSingleton<IActorService, ActorService>()
      .AddSingleton<ICacheService, CacheService>()
      .AddSingleton<IEventSerializer, EventSerializer>();
  }

  private static IServiceCollection AddEventHandlers(this IServiceCollection services)
  {
    WorldEvents.Register(services);
    return services;
  }

  private static IServiceCollection AddQueriers(this IServiceCollection services)
  {
    return services.AddScoped<IWorldQuerier, WorldQuerier>();
  }

  private static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    return services.AddScoped<IWorldRepository, WorldRepository>();
  }

  private static CachingSettings InitializeCachingSettings(this IServiceProvider serviceProvider)
  {
    return CachingSettings.Initialize(serviceProvider.GetRequiredService<IConfiguration>());
  }
}
