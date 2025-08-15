using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class Weapon
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("category")]
  public WeaponCategory Category { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("price")]
  public decimal Price { get; set; }

  [JsonPropertyName("weight")]
  public decimal Weight { get; set; }

  [JsonPropertyName("damage")]
  public WeaponDamage? Damage { get; set; }

  [JsonPropertyName("ammunition")]
  public WeaponRange? Ammunition { get; set; }

  [JsonPropertyName("special")]
  public string? Special { get; set; }

  [JsonPropertyName("thrown")]
  public WeaponRange? Thrown { get; set; }

  [JsonPropertyName("properties")]
  public List<WeaponProperty> Properties { get; set; } = [];

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is Weapon weapon && weapon.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
