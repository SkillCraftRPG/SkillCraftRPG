namespace SkillCraft.Rules.Compiler.Models.Items;

internal record ContainerVolume
{
  [JsonPropertyName("value")]
  public decimal Value { get; set; }

  [JsonPropertyName("unit")]
  public string Unit { get; set; } = string.Empty;

  public ContainerVolume()
  {
  }

  public ContainerVolume(decimal value, string unit)
  {
    Value = value;
    Unit = unit;
  }
}
