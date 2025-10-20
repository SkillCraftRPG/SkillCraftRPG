using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldCreated(Name Name) : DomainEvent;
