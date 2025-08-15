using SkillCraft.Core;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal record WeaponDamage
{
  [JsonPropertyName("roll")]
  public string Roll { get; set; } = string.Empty;

  [JsonPropertyName("versatile")]
  public string? Versatile { get; set; }

  [JsonPropertyName("type")]
  public DamageType Type { get; set; }

  public WeaponDamage()
  {
  }

  public WeaponDamage(string roll, DamageType type, string? versatile = null)
  {
    Roll = roll;
    Versatile = versatile;
    Type = type;
  }
}
