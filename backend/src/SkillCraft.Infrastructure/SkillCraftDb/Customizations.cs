using Logitar.Data;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.SkillCraftDb;

internal static class Customizations
{
  public static readonly TableId Table = new(nameof(SkillCraftContext.Customizations));

  public static readonly ColumnId CustomizationId = new(nameof(CustomizationEntity.CustomizationId), Table);
  public static readonly ColumnId Description = new(nameof(CustomizationEntity.Description), Table);
  public static readonly ColumnId EntityId = new(nameof(CustomizationEntity.EntityId), Table);
  public static readonly ColumnId Kind = new(nameof(CustomizationEntity.Kind), Table);
  public static readonly ColumnId Name = new(nameof(CustomizationEntity.Name), Table);
  public static readonly ColumnId WorldId = new(nameof(CustomizationEntity.WorldId), Table);
  public static readonly ColumnId WorldUid = new(nameof(CustomizationEntity.WorldUid), Table);
}
