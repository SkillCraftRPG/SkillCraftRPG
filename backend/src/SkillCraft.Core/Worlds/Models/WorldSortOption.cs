using Krakenar.Contracts.Search;

namespace SkillCraft.Core.Worlds.Models;

public record WorldSortOption : SortOption
{
  public new WorldSort Field
  {
    get => Enum.Parse<WorldSort>(base.Field);
    set => base.Field = value.ToString();
  }

  public WorldSortOption() : this(WorldSort.Name)
  {
  }

  public WorldSortOption(WorldSort field, bool isDescending = false) : base(field.ToString(), isDescending)
  {
  }
}
