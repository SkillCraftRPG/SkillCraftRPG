using Krakenar.Contracts;

namespace SkillCraft.Core.Worlds.Models;

public class WorldModel : Aggregate
{
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
