using FluentValidation;
using SkillCraft.Rules.Compiler.Models.Items;

namespace SkillCraft.Rules.Compiler.Validators.Items;

internal class GoodsValidator : AbstractValidator<GoodsPayload>
{
  public GoodsValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.Category).IsInEnum();
    RuleFor(x => x.Slug).Slug();
    RuleFor(x => x.Name).Name();
    RuleFor(x => x.Description).Description();

    RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    RuleFor(x => x.Weight).GreaterThanOrEqualTo(0);
  }
}
