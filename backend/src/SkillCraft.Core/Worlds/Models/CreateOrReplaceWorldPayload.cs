namespace SkillCraft.Core.Worlds.Models;

public record CreateOrReplaceWorldPayload
{
  public string Name { get; set; }
  public string? Description { get; set; }

  public CreateOrReplaceWorldPayload() : this(string.Empty)
  {
  }

  public CreateOrReplaceWorldPayload(string name)
  {
    Name = name;
  }
}
