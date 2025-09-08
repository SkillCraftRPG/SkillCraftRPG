namespace SkillCraft.Core.Worlds.Models;

public record CreateOrReplaceWorldPayload
{
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
}
