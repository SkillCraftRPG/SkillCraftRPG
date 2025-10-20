using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

public interface IApplicationContext
{
  UserId UserId { get; }
  WorldId WorldId { get; }
}
