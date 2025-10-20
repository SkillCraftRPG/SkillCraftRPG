using Logitar.EventSourcing;

namespace SkillCraft.Core.Customizations.Events;

public record CustomizationUpdated : DomainEvent
{
  public Name? Name { get; set; }
  public Change<Description>? Description { get; set; }
}
