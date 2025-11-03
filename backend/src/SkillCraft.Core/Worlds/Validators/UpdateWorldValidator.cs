using FluentValidation;
using SkillCraft.Core.Worlds.Models;

namespace SkillCraft.Core.Worlds.Validators;

internal class UpdateWorldValidator : AbstractValidator<UpdateWorldPayload>
{
  public UpdateWorldValidator()
  {
    When(x => !string.IsNullOrWhiteSpace(x.Name), () => RuleFor(x => x.Name!).DisplayName());
    When(x => !string.IsNullOrWhiteSpace(x.Description?.Value), () => RuleFor(x => x.Description!.Value!).Description());
  }
}
