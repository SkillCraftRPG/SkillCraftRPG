using Logitar.EventSourcing;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddSkillCraftCore(this IServiceCollection services)
  {
    WorldService.Register(services);
    return services.AddLogitarEventSourcing();
  }
}
