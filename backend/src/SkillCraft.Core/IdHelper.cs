using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds;

namespace SkillCraft.Core;

internal static class IdHelper
{
  private const char Separator = '|';
  private const char EntitySeparator = ':';

  public static StreamId Combine(string entityKind, Guid entityId, WorldId? worldId = null)
  {
    List<string> values = new(capacity: 2);
    if (worldId.HasValue)
    {
      values.Add(worldId.Value.Value);
    }
    values.Add(string.Join(EntitySeparator, entityKind, Convert.ToBase64String(entityId.ToByteArray()).ToUriSafeBase64()));
    return new StreamId(string.Join(Separator, values));
  }

  public static Tuple<WorldId?, Guid> Parse(string value, string expectedKind)
  {
    string[] values = value.Split(Separator);
    if (values.Length < 1 || values.Length > 2)
    {
      throw new ArgumentException($"The value '{value}' is not a valid identifier.", nameof(value));
    }

    WorldId? worldId = values.Length == 2 ? new(values.First()) : null;

    string[] entity = values.Last().Split(EntitySeparator);
    if (entity.Length != 2)
    {
      throw new ArgumentException($"The value '{values.Last()}' is not a valid entity identifier.", nameof(value));
    }
    else if (entity.First() != expectedKind)
    {
      throw new ArgumentException($"The entity kind '{entity.First()}' was not expected ({expectedKind}).", nameof(value));
    }
    Guid entityId = new(Convert.FromBase64String(entity.Last().FromUriSafeBase64()));

    return new Tuple<WorldId?, Guid>(worldId, entityId);
  }
}
