using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds;

public readonly struct WorldId
{
  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public Guid EntityId => StreamId.ToGuid();

  public WorldId(StreamId streamId)
  {
    StreamId = streamId;
  }

  public WorldId(Guid value)
  {
    StreamId = new(value);
  }

  public WorldId(string value)
  {
    StreamId = new(value);
  }

  public static WorldId NewId() => new(Guid.NewGuid());

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
