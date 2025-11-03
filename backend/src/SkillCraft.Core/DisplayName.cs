using FluentValidation;

namespace SkillCraft.Core;

public record DisplayName
{
  public const int MaximumLength = byte.MaxValue;

  public string Value { get; }

  public DisplayName(string value)
  {
    Value = value.Trim();
  }

  public static DisplayName? TryCreate(string? value) => string.IsNullOrWhiteSpace(value) ? null : new(value);

  public override string ToString() => Value;

  private class Validator : AbstractValidator<DisplayName>
  {
    public Validator()
    {
      RuleFor(x => x.Value).DisplayName();
    }
  }
}
