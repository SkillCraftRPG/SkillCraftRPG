using Logitar.EventSourcing;

namespace SkillCraft.Core;

public interface ICommand<T>;

public interface ICommandBus
{
  Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
  Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface IEventHandler<T> where T : IEvent
{
  Task HandleAsync(T @event, CancellationToken cancellationToken = default);
}

public interface IQuery<T>;

public interface IQueryBus
{
  Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> command, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
  Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
