using Krakenar.Contracts;

namespace SkillCraft.Core.Worlds.Models;

public record UpdateWorldPayload
{
  public string? Name { get; set; } = string.Empty;
  public Change<string>? Description { get; set; }
}
