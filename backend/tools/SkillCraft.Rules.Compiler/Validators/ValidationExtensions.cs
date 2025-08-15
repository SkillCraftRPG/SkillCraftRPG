using FluentValidation;

namespace SkillCraft.Rules.Compiler.Validators;

internal static class ValidationExtensions
{
  public static IRuleBuilderOptions<T, int> Defense<T>(this IRuleBuilder<T, int> ruleBuilder)
  {
    return ruleBuilder.GreaterThan(0);
  }

  public static IRuleBuilderOptions<T, string> Description<T>(this IRuleBuilder<T, string> ruleBuilder)
  {
    return ruleBuilder.NotEmpty();
  }

  public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> ruleBuilder)
  {
    return ruleBuilder.NotEmpty().MaximumLength(40);
  }

  public static IRuleBuilderOptions<T, int> Resistance<T>(this IRuleBuilder<T, int> ruleBuilder)
  {
    return ruleBuilder.GreaterThan(0);
  }

  public static IRuleBuilderOptions<T, string> Roll<T>(this IRuleBuilder<T, string> ruleBuilder)
  {
    return ruleBuilder.NotEmpty().MaximumLength(RollValidator<T>.MaximumLength).SetValidator(new RollValidator<T>());
  }

  public static IRuleBuilderOptions<T, string> Slug<T>(this IRuleBuilder<T, string> ruleBuilder)
  {
    return ruleBuilder.NotEmpty().MaximumLength(40).SetValidator(new SlugValidator<T>());
  }

  public static IRuleBuilderOptions<T, string> Summary<T>(this IRuleBuilder<T, string> ruleBuilder)
  {
    return ruleBuilder.NotEmpty().MaximumLength(byte.MaxValue); // TODO(fpion): should not exceed 160 characters.
  }
}
