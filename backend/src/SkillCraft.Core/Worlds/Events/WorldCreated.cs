using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldCreated(UserId OwnerId, Name Name) : DomainEvent;
