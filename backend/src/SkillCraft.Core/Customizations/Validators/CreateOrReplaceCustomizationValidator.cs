using FluentValidation;
using SkillCraft.Core.Customizations.Models;

namespace SkillCraft.Core.Customizations.Validators;

internal class CreateOrReplaceCustomizationValidator : AbstractValidator<CreateOrReplaceCustomizationPayload>
{
  public CreateOrReplaceCustomizationValidator()
  {
    RuleFor(x => x.Kind).IsInEnum();
    RuleFor(x => x.Name).Name();
    When(x => !string.IsNullOrWhiteSpace(x.Description), () => RuleFor(x => x.Description!).Description());
  }
}
