using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Caching;

public interface ICacheService
{
  Actor? GetActor(ActorId actorId);
  void RemoveActor(ActorId actorId);
  void SetActor(Actor actor);
}
