namespace SkillCraft.Core.Customizations;

public interface ICustomizationRepository
{
  Task<Customization?> LoadAsync(CustomizationId id, CancellationToken cancellationToken = default);

  Task SaveAsync(Customization customization, CancellationToken cancellationToken = default);
  Task SaveAsync(IEnumerable<Customization> customizations, CancellationToken cancellationToken = default);
}
