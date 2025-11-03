using Microsoft.Extensions.Configuration;

namespace SkillCraft.Infrastructure.Settings;

internal record CachingSettings
{
  private const string SectionKey = "Caching";

  public TimeSpan ActorLifetime { get; set; }

  public static CachingSettings Initialize(IConfiguration configuration)
  {
    CachingSettings settings = configuration.GetSection(SectionKey).Get<CachingSettings>() ?? new();

    string? actorLifetimeValue = Environment.GetEnvironmentVariable("CACHING_ACTOR_LIFETIME");
    if (!string.IsNullOrWhiteSpace(actorLifetimeValue) && TimeSpan.TryParse(actorLifetimeValue, out TimeSpan actorLifetime))
    {
      settings.ActorLifetime = actorLifetime;
    }

    return settings;
  }
}
