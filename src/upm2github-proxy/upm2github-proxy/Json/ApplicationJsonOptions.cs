using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using upm2github_proxy.Extensions;

namespace upm2github_proxy.Json
{
    public class ApplicationJsonOptions
    {
        public static JsonSerializerOptions SerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            Converters = { new IsoDateTimeOffsetJsonConverter() }
        };

        public static void AddOptions(JsonOptions jsonOptions)
        {
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = SerializerOptions.DefaultIgnoreCondition;
            jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = SerializerOptions.PropertyNamingPolicy;
            jsonOptions.JsonSerializerOptions.WriteIndented = SerializerOptions.WriteIndented;
            jsonOptions.JsonSerializerOptions.Converters.AddRange (SerializerOptions.Converters);
        }
    }
}
