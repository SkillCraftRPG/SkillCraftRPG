using SkillCraft.Contracts;
using SkillCraft.Core.Models;

namespace SkillCraft.Core.Customizations.Models;

public class CustomizationModel : AggregateModel
{
  public CustomizationKind Kind { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
}
