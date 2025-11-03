using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldCreated(UserId OwnerId, DisplayName Name) : DomainEvent;
