using SkillCraft.Core.Models;

namespace SkillCraft.Core.Worlds.Models;

public class WorldModel : AggregateModel
{
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
}
