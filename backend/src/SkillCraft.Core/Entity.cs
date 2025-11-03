using FluentValidation;

namespace SkillCraft.Core;

public interface IEntity
{
  string Kind { get; }
  string Identifier { get; }
}

internal record Entity : IEntity
{
  private const int MaximumLength = byte.MaxValue;

  public string Kind { get; }
  public string Identifier { get; }

  [JsonConstructor]
  public Entity(string kind, string identifier)
  {
    Kind = kind.Trim();
    Identifier = identifier.Trim();
    new Validator().ValidateAndThrow(this);
  }

  public Entity(IEntity entity) : this(entity.Kind, entity.Identifier)
  {
  }

  internal class Validator : AbstractValidator<IEntity>
  {
    public Validator()
    {
      RuleFor(x => x.Kind).NotEmpty().MaximumLength(MaximumLength);
      RuleFor(x => x.Identifier).NotEmpty().MaximumLength(MaximumLength);
    }
  }
}
