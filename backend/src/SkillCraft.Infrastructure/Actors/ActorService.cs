using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;
using SkillCraft.Core.Caching;

namespace SkillCraft.Infrastructure.Actors;

public interface IActorService
{
  Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> ids, CancellationToken cancellationToken = default);
}

internal class ActorService : IActorService
{
  private readonly ICacheService _cacheService;

  public ActorService(ICacheService cacheService)
  {
    _cacheService = cacheService;
  }

  public Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> ids, CancellationToken cancellationToken)
  {
    int capacity = ids.Count();
    Dictionary<ActorId, Actor> actors = new(capacity);
    HashSet<ActorId> missingIds = new(capacity);

    foreach (ActorId id in ids)
    {
      Actor? actor = _cacheService.GetActor(id);
      if (actor is null)
      {
        missingIds.Add(id);
      }
      else
      {
        actors[id] = actor;
      }
    }

    if (missingIds.Count > 0)
    {
      // TODO(fpion): implement
    }

    foreach (Actor actor in actors.Values)
    {
      _cacheService.SetActor(actor);
    }

    return Task.FromResult((IReadOnlyDictionary<ActorId, Actor>)actors.AsReadOnly());
  }
}
