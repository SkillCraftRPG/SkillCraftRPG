﻿namespace SkillCraft.Tools.Shared.Models;

public class SpecializationDto
{
  public Guid Id { get; set; }

  public bool IsPublished { get; set; }

  public string Slug { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;

  public int Tier { get; set; }

  public string? Summary { get; set; }
  public string? MetaDescription { get; set; }
  public string? Description { get; set; }

  public SpecializationRequirementsDto Requirements { get; set; } = new();
  public SpecializationOptionsDto Options { get; set; } = new();
  public ReservedTalentDto? ReservedTalent { get; set; }

  public override bool Equals(object? obj) => obj is SpecializationDto specialization && specialization.Id == Id;
  public override int GetHashCode() => Id.GetHashCode();
  public override string ToString() => $"{Name} | {GetType()} (Id={Id})";
}
