using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class Armor
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("category")]
  public ArmorCategory Category { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("price")]
  public decimal Price { get; set; }

  [JsonPropertyName("weight")]
  public decimal Weight { get; set; }

  [JsonPropertyName("defense")]
  public int Defense { get; set; }

  [JsonPropertyName("resistance")]
  public int Resistance { get; set; }

  [JsonPropertyName("properties")]
  public List<ArmorProperty> Properties { get; set; } = [];

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is Armor armor && armor.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
