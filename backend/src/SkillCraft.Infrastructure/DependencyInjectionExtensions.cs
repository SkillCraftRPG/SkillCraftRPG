using Logitar.EventSourcing.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SkillCraft.Infrastructure;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftInfrastructure(this IServiceCollection services)
  {
    return services.AddSingleton<IEventSerializer, EventSerializer>();
  }
}
