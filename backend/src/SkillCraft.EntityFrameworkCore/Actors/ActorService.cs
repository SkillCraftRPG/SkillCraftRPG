using Krakenar.Contracts.Actors;
using Logitar.EventSourcing;

namespace SkillCraft.EntityFrameworkCore.Actors;

internal interface IActorService
{
  Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken = default);
}

internal class ActorService : IActorService
{
  public Task<IReadOnlyDictionary<ActorId, Actor>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }
}
