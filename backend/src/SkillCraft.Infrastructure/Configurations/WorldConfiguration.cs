using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Configurations;

internal class WorldConfiguration : AggregateConfiguration<WorldEntity>, IEntityTypeConfiguration<WorldEntity>
{
  public override void Configure(EntityTypeBuilder<WorldEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Worlds.Table.Table!, SkillCraftDb.Worlds.Table.Schema);
    builder.HasKey(x => x.WorldId);

    builder.HasIndex(x => x.EntityId).IsUnique();
    builder.HasIndex(x => x.OwnerId);
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Name).HasMaxLength(Name.MaximumLength);
  }
}
