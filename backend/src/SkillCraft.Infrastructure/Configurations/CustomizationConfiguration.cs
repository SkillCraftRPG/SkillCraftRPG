using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.Core;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Configurations;

internal class CustomizationConfiguration : AggregateConfiguration<CustomizationEntity>, IEntityTypeConfiguration<CustomizationEntity>
{
  public override void Configure(EntityTypeBuilder<CustomizationEntity> builder)
  {
    base.Configure(builder);

    builder.ToTable(SkillCraftDb.Customizations.Table.Table!, SkillCraftDb.Customizations.Table.Schema);
    builder.HasKey(x => x.CustomizationId);

    builder.HasIndex(x => new { x.WorldId, x.EntityId }).IsUnique();
    builder.HasIndex(x => x.WorldUid);
    builder.HasIndex(x => x.Kind);
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Name).HasMaxLength(Name.MaximumLength);

    builder.HasOne(x => x.World).WithMany(x => x.Customizations).OnDelete(DeleteBehavior.Restrict);
  }
}
