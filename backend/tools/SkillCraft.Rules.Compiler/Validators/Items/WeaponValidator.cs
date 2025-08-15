using FluentValidation;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class WeaponValidator : AbstractValidator<WeaponPayload>
{
  public WeaponValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Category).IsInEnum();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Weight).GreaterThanOrEqualTo(0);

    When(x => !string.IsNullOrWhiteSpace(x.DamageRoll) || x.DamageType.HasValue || !string.IsNullOrWhiteSpace(x.Versatile), () =>
    {
      When(x => !string.IsNullOrWhiteSpace(x.DamageRoll), () => RuleFor(x => x.DamageRoll!).Roll())
        .Otherwise(() => RuleFor(x => x.DamageRoll).NotEmpty());
      RuleFor(x => x.DamageType).IsInEnum();
      When(x => !string.IsNullOrWhiteSpace(x.Versatile), () => RuleFor(x => x.Versatile!).Roll());
    }).Otherwise(() =>
    {
      RuleFor(x => x.DamageRoll).Empty();
      RuleFor(x => x.DamageType).Null();
      RuleFor(x => x.Versatile).Empty();
    });

    When(x => x.AmmunitionStandard.HasValue || x.AmmunitionLong.HasValue, () =>
    {
      RuleFor(x => x.AmmunitionStandard).GreaterThan(0);
      RuleFor(x => x.AmmunitionLong).GreaterThan(x => x.AmmunitionStandard);
    }).Otherwise(() =>
    {
      RuleFor(x => x.AmmunitionStandard).Null();
      RuleFor(x => x.AmmunitionLong).Null();
    });

    When(x => x.ThrownStandard.HasValue || x.ThrownLong.HasValue, () =>
    {
      RuleFor(x => x.ThrownStandard).GreaterThan(0);
      RuleFor(x => x.ThrownLong).GreaterThan(x => x.ThrownStandard);
    }).Otherwise(() =>
    {
      RuleFor(x => x.ThrownStandard).Null();
      RuleFor(x => x.ThrownLong).Null();
    });

    RuleFor(x => x.Properties).Must(BeValidWeaponProperties)
      .WithErrorCode("PropertiesValidator")
      .WithMessage("'{PropertyName}' must be a list of weapon properties separated by a comma (,).");
  }

  private static bool BeValidWeaponProperties(string? properties)
  {
    if (string.IsNullOrWhiteSpace(properties))
    {
      return true;
    }

    return properties.Split(',').All(value => Enum.TryParse(value.Trim(), ignoreCase: true, out WeaponProperty property) && Enum.IsDefined(property));
  }
}
