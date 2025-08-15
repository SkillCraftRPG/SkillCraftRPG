using CsvHelper.Configuration.Attributes;
using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class ArmorPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("category")]
  public ArmorCategory Category { get; set; }

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
  [Name("defense")]
  public int Defense { get; set; }

  [Index(7)]
  [Name("resistance")]
  public int Resistance { get; set; }

  [Index(8)]
  [Name("properties")]
  public string? Properties { get; set; }

  [Index(9)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is ArmorPayload armor && armor.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
