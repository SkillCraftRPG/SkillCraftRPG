namespace SkillCraft.Core.Customizations;

public interface ICustomizationManager
{
  Task SaveAsync(Customization customization, CancellationToken cancellationToken = default);
}

internal class CustomizationManager : ICustomizationManager
{
  private readonly ICustomizationRepository _customizationRepository;

  public CustomizationManager(ICustomizationRepository customizationRepository)
  {
    _customizationRepository = customizationRepository;
  }

  public async Task SaveAsync(Customization customization, CancellationToken cancellationToken)
  {
    // TODO(fpion): ensure enough storage

    await _customizationRepository.SaveAsync(customization, cancellationToken);

    // TODO(fpion): update storage
  }
}
