using CsvHelper.Configuration.Attributes;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class ItemPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("slug")]
  public string Slug { get; set; } = string.Empty;

  [Index(2)]
  [Name("name")]
  public string Name { get; set; } = string.Empty;

  [Index(3)]
  [Name("price")]
  public decimal Price { get; set; }

  [Index(4)]
  [Name("weight")]
  public decimal Weight { get; set; }

  [Index(5)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is ItemPayload item && item.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
