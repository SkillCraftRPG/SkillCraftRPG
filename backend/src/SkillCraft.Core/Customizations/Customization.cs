using Logitar.EventSourcing;
using SkillCraft.Core.Customizations.Events;

namespace SkillCraft.Core.Customizations;

public class Customization : AggregateRoot
{
  private CustomizationUpdated _updated = new();
  private bool HasUpdates => _updated.Name is not null || _updated.Description is not null;

  private Name? _name = null;
  public Name Name
  {
    get => _name ?? throw new InvalidOperationException("The name has not been initialized.");
    set
    {
      if (_name != value)
      {
        _name = value;
        _updated.Name = new Change<Name>(value);
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

  public Customization() : base()
  {
  }

  public Customization(Name name, ActorId? actorId = null, CustomizationId? customizationId = null)
    : base(/*(customizationId ?? CustomizationId.NewId()).StreamId*/) // TODO(fpion): implement
  {
    Raise(new CustomizationCreated(name), actorId);
  }
  protected virtual void Handle(CustomizationCreated @event)
  {
    _name = @event.Name;
  }

  public void Update(ActorId? actorId = null)
  {
    if (HasUpdates)
    {
      Raise(_updated, actorId, DateTime.Now);
      _updated = new();
    }
  }
  protected virtual void Handle(CustomizationUpdated @event)
  {
    if (@event.Name is not null)
    {
      _name = @event.Name.Value;
    }
    if (@event.Description is not null)
    {
      _description = @event.Description.Value;
    }
  }
}
