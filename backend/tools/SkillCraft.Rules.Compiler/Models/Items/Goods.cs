using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class Goods
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

  [JsonPropertyName("category")]
  public GoodsCategory Category { get; set; }

  [JsonPropertyName("slug")]
  public string Slug { get; set; } = string.Empty;

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

  [JsonPropertyName("price")]
  public decimal Price { get; set; }

  [JsonPropertyName("weight")]
  public decimal Weight { get; set; }

  [JsonPropertyName("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is Goods goods && goods.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
