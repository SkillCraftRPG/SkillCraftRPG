namespace SkillCraft.Core.Worlds.Models;

public record UpdateWorldPayload
{
  public string? Name { get; set; }
  public Change<string?>? Description { get; set; }
}
