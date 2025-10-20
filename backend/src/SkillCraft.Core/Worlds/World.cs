using Logitar.EventSourcing;
using SkillCraft.Core.Worlds.Events;

namespace SkillCraft.Core.Worlds;

public class World : AggregateRoot
{
  private WorldUpdated _updated = new();
  private bool HasUpdates => _updated.Name is not null || _updated.Description is not null;

  public new WorldId Id => new(base.Id);

  public UserId OwnerId { get; private set; }

  private Name? _name = null;
  public Name Name
  {
    get => _name ?? throw new InvalidOperationException("The name has not been initialized.");
    set
    {
      if (_name != value)
      {
        _name = value;
        _updated.Name = value;
      }
    }
  }
  private Description? _description = null;
  public Description? Description
  {
    get => _description;
    set
    {
      if (_description != value)
      {
        _description = value;
        _updated.Description = new Change<Description>(value);
      }
    }
  }

  public World() : base()
  {
  }

  public World(Name name, UserId userId, WorldId worldId)
    : base(worldId.StreamId)
  {
    Raise(new WorldCreated(userId, name), userId.ActorId);
  }
  protected virtual void Handle(WorldCreated @event)
  {
    OwnerId = @event.OwnerId;

    _name = @event.Name;
  }

  public void Update(UserId userId)
  {
    if (HasUpdates)
    {
      Raise(_updated, userId.ActorId, DateTime.Now);
      _updated = new();
    }
  }
  protected virtual void Handle(WorldUpdated @event)
  {
    if (@event.Name is not null)
    {
      _name = @event.Name;
    }
    if (@event.Description is not null)
    {
      _description = @event.Description.Value;
    }
  }
}
