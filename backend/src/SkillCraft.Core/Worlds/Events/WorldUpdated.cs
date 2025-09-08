using Krakenar.Core;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldUpdated : DomainEvent
{
  public DisplayName? Name { get; set; }
  public Change<Description>? Description { get; set; }
}
