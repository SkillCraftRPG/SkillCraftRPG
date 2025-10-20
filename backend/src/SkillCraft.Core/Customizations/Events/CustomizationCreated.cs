using Logitar.EventSourcing;

namespace SkillCraft.Core.Customizations.Events;

public record CustomizationCreated(Name Name) : DomainEvent;
