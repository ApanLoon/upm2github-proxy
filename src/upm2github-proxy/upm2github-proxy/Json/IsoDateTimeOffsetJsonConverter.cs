using System.Text.Json;
using System.Text.Json.Serialization;

namespace upm2github_proxy.Json
{
    public class IsoDateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            if (s == null)
            {
                throw new JsonException("Failed to read DateTimeOffset");
            }
            return DateTimeOffset.Parse(s);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Offset == TimeSpan.Zero
                ? value.ToString("yyyy-MM-ddTHH:mm:ss.FFFZ")
                : value.ToString("yyyy-MM-ddTHH:mm:ss.FFFK"));
        }
    }
}
