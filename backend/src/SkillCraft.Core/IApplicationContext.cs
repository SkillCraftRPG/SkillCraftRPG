using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public interface IApplicationContext
{
  ActorId? ActorId { get; }
  WorldId WorldId { get; }
}
