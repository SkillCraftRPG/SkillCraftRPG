using SkillCraft.Contracts;

namespace SkillCraft.Core.Customizations.Models;

public record CreateOrReplaceCustomizationPayload
{
  public CustomizationKind Kind { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }

  public CreateOrReplaceCustomizationPayload() : this(string.Empty)
  {
  }

  public CreateOrReplaceCustomizationPayload(string name)
  {
    Name = name;
  }
}
