using SkillCraft.Core.Customizations.Models;

namespace SkillCraft.Core.Customizations;

public interface ICustomizationQuerier
{
  Task<CustomizationModel> ReadAsync(Customization customization, CancellationToken cancellationToken = default);
  Task<CustomizationModel?> ReadAsync(CustomizationId customizationId, CancellationToken cancellationToken = default);
  Task<CustomizationModel?> ReadAsync(Guid entityId, CancellationToken cancellationToken = default);
}
