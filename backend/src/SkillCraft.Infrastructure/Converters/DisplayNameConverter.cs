using SkillCraft.Core;

namespace SkillCraft.Infrastructure.Converters;

internal class DisplayNameConverter : JsonConverter<DisplayName>
{
  public override DisplayName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    return DisplayName.TryCreate(reader.GetString());
  }

  public override void Write(Utf8JsonWriter writer, DisplayName displayName, JsonSerializerOptions options)
  {
    writer.WriteStringValue(displayName.Value);
  }
}
