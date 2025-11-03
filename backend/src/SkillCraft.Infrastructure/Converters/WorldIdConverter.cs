using SkillCraft.Core.Worlds;

namespace SkillCraft.Infrastructure.Converters;

internal class WorldIdConverter : JsonConverter<WorldId>
{
  public override WorldId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    string? value = reader.GetString();
    return string.IsNullOrWhiteSpace(value) ? new WorldId() : new(value);
  }

  public override void Write(Utf8JsonWriter writer, WorldId worldId, JsonSerializerOptions options)
  {
    writer.WriteStringValue(worldId.Value);
  }
}
