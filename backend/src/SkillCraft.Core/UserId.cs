using Logitar.EventSourcing;

namespace SkillCraft.Core;

public readonly struct UserId
{
  public ActorId ActorId { get; }
  public string Value => ActorId.Value;

  public UserId(ActorId actorId)
  {
    ActorId = actorId;
  }
  public UserId(Guid value)
  {
    ActorId = new(value);
  }
  public UserId(string value)
  {
    ActorId = new(value);
  }

  public static UserId NewId() => new(Guid.NewGuid());

  public Guid ToGuid() => ActorId.ToGuid();

  public static bool operator ==(UserId left, UserId right) => left.Equals(right);
  public static bool operator !=(UserId left, UserId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is UserId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
