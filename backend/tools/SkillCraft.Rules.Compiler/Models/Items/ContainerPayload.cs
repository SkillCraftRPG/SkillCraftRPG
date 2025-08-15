using CsvHelper.Configuration.Attributes;

namespace SkillCraft.Rules.Compiler.Models.Items;

internal class ContainerPayload
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
  [Name("volume")]
  public decimal? Volume { get; set; }

  [Index(6)]
  [Name("volume_unit")]
  public string? VolumeUnit { get; set; }

  [Index(7)]
  [Name("capacity")]
  public decimal? Capacity { get; set; }

  [Index(8)]
  [Name("description")]
  public string Description { get; set; } = string.Empty;

  public override bool Equals(object? obj) => obj is ContainerPayload container && container.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
