using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldUpdated : DomainEvent
{
  public Name? Name { get; set; }
  public Change<Description>? Description { get; set; }
}
