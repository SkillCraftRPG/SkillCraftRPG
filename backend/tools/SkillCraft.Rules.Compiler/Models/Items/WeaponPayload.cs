using CsvHelper.Configuration.Attributes;
using SkillCraft.Core;
using SkillCraft.Core.Items;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class WeaponPayload
{
  [Index(0)]
  [Name("id")]
  public Guid Id { get; set; }

  [Index(1)]
  [Name("category")]
  public WeaponCategory Category { get; set; }

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
  [Name("damage_roll")]
  public string? DamageRoll { get; set; }

  [Index(7)]
  [Name("damage_type")]
  public DamageType? DamageType { get; set; }

  [Index(8)]
  [Name("ammunition_standard")]
  public int? AmmunitionStandard { get; set; }

  [Index(9)]
  [Name("ammunition_long")]
  public int? AmmunitionLong { get; set; }

  [Index(10)]
  [Name("special")]
  public string? Special { get; set; }

  [Index(11)]
  [Name("thrown_standard")]
  public int? ThrownStandard { get; set; }

  [Index(12)]
  [Name("thrown_long")]
  public int? ThrownLong { get; set; }

  [Index(13)]
  [Name("versatile")]
  public string? Versatile { get; set; }

  [Index(14)]
  [Name("properties")]
  public string? Properties { get; set; }

  [Index(15)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is WeaponPayload weapon && weapon.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
