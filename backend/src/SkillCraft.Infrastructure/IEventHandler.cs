using Logitar.EventSourcing;

namespace SkillCraft.Infrastructure;

public interface IEventHandler<T> where T : IEvent
{
  Task HandleAsync(T @event, CancellationToken cancellationToken = default);
}
