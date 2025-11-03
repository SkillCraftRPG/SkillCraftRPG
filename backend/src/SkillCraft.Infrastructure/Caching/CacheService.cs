using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using Microsoft.Extensions.Caching.Memory;
using SkillCraft.Core.Caching;
using SkillCraft.Infrastructure.Settings;

namespace SkillCraft.Infrastructure.Caching;

internal class CacheService : ICacheService
{
  private readonly IMemoryCache _cache;
  private readonly CachingSettings _settings;

  public CacheService(IMemoryCache cache, CachingSettings settings)
  {
    _cache = cache;
    _settings = settings;
  }

  public Actor? GetActor(ActorId actorId) => Get<Actor>(GetActorKey(actorId));
  public void RemoveActor(ActorId actorId) => Remove(GetActorKey(actorId));
  public void SetActor(Actor actor)
  {
    ActorId actorId = new(); // TODO(fpion): implement
    Set(GetActorKey(actorId), actor, _settings.ActorLifetime);
  }
  private static string GetActorKey(ActorId id) => $"Actor.Id={id}";

  private T? Get<T>(string key) => _cache.TryGetValue(key, out object? value) ? (T?)value : default;
  private void Remove(string key) => _cache.Remove(key);
  private void Set<T>(string key, T value, TimeSpan? expiration = null)
  {
    if (expiration.HasValue)
    {
      _cache.Set(key, value, expiration.Value);
    }
    else
    {
      _cache.Set(key, value);
    }
  }
}
