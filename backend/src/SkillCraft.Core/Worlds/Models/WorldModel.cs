using AggregateModel = Krakenar.Contracts.Aggregate;

namespace SkillCraft.Core.Worlds.Models;

public class WorldModel : AggregateModel
{
  public string Name { get; set; }
  public string? Description { get; set; }

  public WorldModel() : this(string.Empty)
  {
  }

  public WorldModel(string name)
  {
    Name = name;
  }
}
