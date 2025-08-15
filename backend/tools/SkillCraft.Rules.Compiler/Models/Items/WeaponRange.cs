namespace SkillCraft.Rules.Compiler.Models.Items;

internal record WeaponRange
{
  [JsonPropertyName("standard")]
  public int Standard { get; set; }

  [JsonPropertyName("long")]
  public int Long { get; set; }

  public WeaponRange()
  {
  }

  public WeaponRange(int standard, int @long)
  {
    Standard = standard;
    Long = @long;
  }
}
