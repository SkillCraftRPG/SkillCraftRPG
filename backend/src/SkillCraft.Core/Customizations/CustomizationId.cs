using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Customizations;

public readonly struct CustomizationId
{
  private const string EntityKind = "Customization";

  public StreamId StreamId { get; }
  public string Value => StreamId.Value;

  public WorldId WorldId { get; }
  public Guid EntityId { get; }

  public CustomizationId(StreamId streamId)
  {
    StreamId = streamId;

    Tuple<WorldId?, Guid> values = IdHelper.Parse(Value, EntityKind);
    WorldId = values.Item1 ?? throw new ArgumentException($"The value '{streamId}' must include a world identifier.", nameof(streamId));
    EntityId = values.Item2;
  }

  public CustomizationId(WorldId worldId, Guid entityId)
  {
    StreamId = IdHelper.Combine(EntityKind, entityId, worldId);

    WorldId = worldId;
    EntityId = entityId;
  }

  public CustomizationId(string value)
  {
    StreamId = new(value);

    Tuple<WorldId?, Guid> values = IdHelper.Parse(Value, EntityKind);
    WorldId = values.Item1 ?? throw new ArgumentException($"The value '{value}' must include a world identifier.", nameof(value));
    EntityId = values.Item2;
  }

  public static CustomizationId NewId(WorldId worldId) => new(worldId, Guid.NewGuid());

  public static bool operator ==(CustomizationId left, CustomizationId right) => left.Equals(right);
  public static bool operator !=(CustomizationId left, CustomizationId right) => !left.Equals(right);

  public override bool Equals([NotNullWhen(true)] object? obj) => obj is CustomizationId id && id.Value == Value;
  public override int GetHashCode() => Value.GetHashCode();
  public override string ToString() => Value;
}
