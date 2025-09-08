using Logitar;
using Logitar.EventSourcing;

namespace SkillCraft.EntityFrameworkCore.Entities;

internal abstract class AggregateEntity
{
  public string StreamId { get; private set; } = string.Empty;
  public long Version { get; private set; }

  public string? CreatedBy { get; private set; }
  public DateTime CreatedOn { get; private set; }

  public string? UpdatedBy { get; private set; }
  public DateTime UpdatedOn { get; private set; }

  protected AggregateEntity()
  {
  }

  protected AggregateEntity(DomainEvent @event)
  {
    StreamId = @event.StreamId.Value;

    CreatedBy = @event.ActorId?.Value;
    CreatedOn = @event.OccurredOn.AsUniversalTime();

    Update(@event);
  }

  public virtual IReadOnlyCollection<ActorId> GetActorIds()
  {
    HashSet<ActorId> actorIds = new(capacity: 2);
    if (!string.IsNullOrWhiteSpace(CreatedBy))
    {
      actorIds.Add(new ActorId(CreatedBy));
    }
    if (!string.IsNullOrWhiteSpace(UpdatedBy))
    {
      actorIds.Add(new ActorId(UpdatedBy));
    }
    return actorIds;
  }

  public void Update(DomainEvent @event)
  {
    Version = @event.Version;

    UpdatedBy = @event.ActorId?.Value;
    UpdatedOn = @event.OccurredOn.AsUniversalTime();
  }
}
