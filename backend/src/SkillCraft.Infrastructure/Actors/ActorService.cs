using Logitar.EventSourcing;
using SkillCraft.Core.Models;

namespace SkillCraft.Infrastructure.Actors;

public interface IActorService
{
  Task<IReadOnlyDictionary<ActorId, ActorModel>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken = default);
}

internal class ActorService : IActorService
{
  public Task<IReadOnlyDictionary<ActorId, ActorModel>> FindAsync(IEnumerable<ActorId> actorIds, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }
}
