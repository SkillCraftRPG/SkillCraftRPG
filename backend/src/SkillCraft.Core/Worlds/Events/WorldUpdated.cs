using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldUpdated : DomainEvent
{
  public Change<Name>? Name { get; set; }
  public Change<Description>? Description { get; set; }
}
