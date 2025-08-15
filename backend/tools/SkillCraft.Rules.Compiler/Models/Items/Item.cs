namespace SkillCraft.Rules.Compiler.Models.Items;

internal class Item
{
  [JsonPropertyName("id")]
  public Guid Id { get; set; }

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

  public override bool Equals(object? obj) => obj is Item item && item.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
