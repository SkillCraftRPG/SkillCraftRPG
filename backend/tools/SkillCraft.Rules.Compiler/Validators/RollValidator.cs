using FluentValidation;
using FluentValidation.Validators;

namespace SkillCraft.Rules.Compiler.Validators;

internal class RollValidator<T> : IPropertyValidator<T, string>
{
  public const int MaximumLength = 6;

  private readonly Regex _regex = new("^([1-9][0-9]?)(?:d([1-9][0-9]{0,2}))?$");

  public string Name { get; } = "RollValidator";

  public string GetDefaultMessageTemplate(string errorCode)
  {
    return "'{PropertyName}' must be a valid dice roll.";
  }

  public bool IsValid(ValidationContext<T> context, string value) => _regex.IsMatch(value);
}
