using Logitar.Data;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.SkillCraftDb;

internal static class Worlds
{
  public static readonly TableId Table = new(nameof(SkillCraftContext.Worlds));

  public static readonly ColumnId Description = new(nameof(WorldEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(WorldEntity.EntityId), Table);
  public static readonly ColumnId Name = new(nameof(WorldEntity.Name), Table);
  public static readonly ColumnId OwnerId = new(nameof(WorldEntity.OwnerId), Table);
  public static readonly ColumnId WorldId = new(nameof(WorldEntity.WorldId), Table);
}
