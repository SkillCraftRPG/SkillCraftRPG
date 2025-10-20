using Logitar.EventSourcing;
using SkillCraft.Contracts;

namespace SkillCraft.Core.Customizations.Events;

public record CustomizationCreated(CustomizationKind Kind, Name Name) : DomainEvent;
