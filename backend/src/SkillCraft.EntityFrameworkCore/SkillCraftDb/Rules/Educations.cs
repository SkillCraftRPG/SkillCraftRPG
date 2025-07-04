﻿using Logitar.Data;
using SkillCraft.EntityFrameworkCore.Entities.Rules;

namespace SkillCraft.EntityFrameworkCore.SkillCraftDb.Rules;

internal static class Educations
{
  public static readonly TableId Table = new(RuleContext.Schema, nameof(RuleContext.Educations), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(EducationEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(EducationEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(EducationEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(EducationEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(EducationEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(EducationEntity.Version), Table);

  public static readonly ColumnId EducationId = new(nameof(EducationEntity.EducationId), Table);
  public static readonly ColumnId Description = new(nameof(EducationEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(EducationEntity.Id), Table);
  public static readonly ColumnId Name = new(nameof(EducationEntity.Name), Table);
  public static readonly ColumnId SkillId = new(nameof(EducationEntity.SkillId), Table);
  public static readonly ColumnId SkillUid = new(nameof(EducationEntity.SkillUid), Table);
  public static readonly ColumnId Slug = new(nameof(EducationEntity.Slug), Table);
  public static readonly ColumnId Summary = new(nameof(EducationEntity.Summary), Table);
  public static readonly ColumnId WealthMultiplier = new(nameof(EducationEntity.WealthMultiplier), Table);
}
