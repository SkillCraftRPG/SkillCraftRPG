using Krakenar.Core;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds.Events;

public record WorldCreated(DisplayName Name) : DomainEvent;
