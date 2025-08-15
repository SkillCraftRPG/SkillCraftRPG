using FluentValidation;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class ArmorValidator : AbstractValidator<ArmorPayload>
{
  public ArmorValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Category).IsInEnum();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Weight).GreaterThanOrEqualTo(0);

    RuleFor(x => x.Defense).Defense();
    RuleFor(x => x.Resistance).Resistance();

    RuleFor(x => x.Properties).Must(BeValidArmorProperties)
      .WithErrorCode("PropertiesValidator")
      .WithMessage("'{PropertyName}' must be a list of armor properties separated by a comma (,).");
  }

  private static bool BeValidArmorProperties(string? properties)
  {
    if (string.IsNullOrWhiteSpace(properties))
    {
      return true;
    }

    return properties.Split(',').All(value => Enum.TryParse(value.Trim(), ignoreCase: true, out ArmorProperty property) && Enum.IsDefined(property));
  }
}
