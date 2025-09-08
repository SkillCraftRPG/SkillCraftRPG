using Krakenar.Core;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds.Events;

namespace SkillCraft.Core.Worlds;

public class World : AggregateRoot
{
  private WorldUpdated _updated = new();
  private bool HasUpdates => _updated.Name is not null || _updated.Description is not null;

  public new WorldId Id => new(base.Id);

  private DisplayName? _name = null;
  public DisplayName Name
  {
    get => _name ?? throw new InvalidOperationException("The world has not been initialized.");
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

  public World(DisplayName name, ActorId? actorId = null, WorldId? worldId = null)
    : base((worldId ?? WorldId.NewId()).StreamId)
  {
    Raise(new WorldCreated(name), actorId);
  }
  protected virtual void Handle(WorldCreated @event)
  {
    _name = @event.Name;
  }

  public void Delete(ActorId? actorId = null)
  {
    if (!IsDeleted)
    {
      Raise(new WorldDeleted(), actorId);
    }
  }

  public void Update(ActorId? actorId = null)
  {
    if (HasUpdates)
    {
      Raise(_updated, actorId);
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

  public override string ToString() => $"{Name.Value} | {base.ToString()}";
}
