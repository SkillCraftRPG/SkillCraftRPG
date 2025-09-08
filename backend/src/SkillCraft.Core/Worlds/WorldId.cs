using Krakenar.Core;
using Logitar.EventSourcing;

namespace SkillCraft.Core.Worlds;

public readonly struct WorldId
{
  private const string EntityType = "World";

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public WorldId(Guid entityId)
  {
    StreamId = IdHelper.Construct(EntityType, entityId);
  }
  public WorldId(StreamId streamId)
  {
    StreamId = streamId;
  }
  public WorldId(string value)
  {
    StreamId = new StreamId(value);
  }

  public static WorldId NewId() => new(Guid.NewGuid());
  public Guid ToGuid() => IdHelper.Deconstruct(StreamId, EntityType).Item1;

  public static bool operator ==(WorldId left, WorldId right) => left.Equals(right);
  public static bool operator !=(WorldId left, WorldId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is WorldId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
