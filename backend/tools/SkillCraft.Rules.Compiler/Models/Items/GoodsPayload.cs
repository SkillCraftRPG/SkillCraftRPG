using CsvHelper.Configuration.Attributes;
using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class GoodsPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("category")]
  public GoodsCategory Category { get; set; }

  [Index(2)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(3)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(4)]
  [Name("price")]
  public decimal Price { get; set; }

  [Index(5)]
  [Name("weight")]
  public decimal Weight { get; set; }

  [Index(6)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is GoodsPayload goods && goods.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
