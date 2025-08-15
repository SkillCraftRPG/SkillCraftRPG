using FluentValidation;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class ContainerValidator : AbstractValidator<ContainerPayload>
{
  public ContainerValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Weight).GreaterThanOrEqualTo(0);

    When(x => x.Volume.HasValue || !string.IsNullOrWhiteSpace(x.VolumeUnit), () =>
    {
      RuleFor(x => x.Volume).GreaterThan(0);
      RuleFor(x => x.VolumeUnit).NotEmpty();
    }).Otherwise(() =>
    {
      RuleFor(x => x.Volume).Null();
      RuleFor(x => x.VolumeUnit).Empty();
    });
    RuleFor(x => x.Capacity).GreaterThan(0);
  }
}
