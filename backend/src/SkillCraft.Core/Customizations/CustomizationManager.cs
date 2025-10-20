using SkillCraft.Core.Storages;

namespace SkillCraft.Core.Customizations;

public interface ICustomizationManager
{
  Task SaveAsync(Customization customization, CancellationToken cancellationToken = default);
}

internal class CustomizationManager : ICustomizationManager
{
  private readonly ICustomizationRepository _customizationRepository;
  private readonly IStorageManager _storageManager;

  public CustomizationManager(ICustomizationRepository customizationRepository, IStorageManager storageManager)
  {
    _customizationRepository = customizationRepository;
    _storageManager = storageManager;
  }

  public async Task SaveAsync(Customization customization, CancellationToken cancellationToken)
  {
    await _storageManager.EnsureAvailableAsync(customization, cancellationToken);

    await _customizationRepository.SaveAsync(customization, cancellationToken);

    await _storageManager.UpdateAsync(customization, cancellationToken);
  }
}
