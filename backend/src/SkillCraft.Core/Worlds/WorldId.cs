using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds;

public readonly struct WorldId
{
  private const string EntityKind = "Customization";

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public Guid EntityId { get; }

  public WorldId(StreamId streamId)
  {
    StreamId = streamId;

    Tuple<WorldId?, Guid> values = IdHelper.Parse(Value, EntityKind);
    if (values.Item1.HasValue)
    {
      throw new ArgumentException($"The value '{streamId}' should not include a world identifier.", nameof(streamId));
    }
    EntityId = values.Item2;
  }

  public WorldId(Guid entityId)
  {
    StreamId = IdHelper.Combine(EntityKind, entityId);

    EntityId = entityId;
  }

  public WorldId(string value)
  {
    StreamId = new(value);

    Tuple<WorldId?, Guid> values = IdHelper.Parse(Value, EntityKind);
    if (values.Item1.HasValue)
    {
      throw new ArgumentException($"The value '{value}' should not include a world identifier.", nameof(value));
    }
    EntityId = values.Item2;
  }

  public static WorldId NewId() => new(Guid.NewGuid());

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
