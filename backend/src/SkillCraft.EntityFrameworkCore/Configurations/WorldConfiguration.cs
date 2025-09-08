using Krakenar.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillCraft.EntityFrameworkCore.Entities;

namespace SkillCraft.EntityFrameworkCore.Configurations;

internal class WorldConfiguration : IEntityTypeConfiguration<WorldEntity>
{
  public void Configure(EntityTypeBuilder<WorldEntity> builder)
  {
    builder.ToTable(SkillCraftDb.Worlds.Table.Table!, SkillCraftDb.Worlds.Table.Schema);
    builder.HasKey(x => x.WorldId);

    builder.HasIndex(x => x.Id).IsUnique();
    builder.HasIndex(x => x.Name);

    builder.Property(x => x.Name).HasMaxLength(DisplayName.MaximumLength);
  }
}
