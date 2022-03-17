using System.Text.Json;
using System.Text.Json.Serialization;
using upm2github_proxy.Models;

namespace upm2github_proxy.Json;

public class LinkListJsonConverter : JsonConverter<LinkList>
{
    public override LinkList? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var linkList = new LinkList();

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected object");
        }

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            var link = new Link();

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected property name");
            }
            link.Name = reader.GetString() ?? throw new JsonException("Link name can't be null");

            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException("Expected property string value");
            }
            link.Url = reader.GetString() ?? throw new JsonException("Url can't be null");
            
            linkList.Add(link);
        }

        if (reader.TokenType != JsonTokenType.EndObject)
        {
            throw new JsonException("Expected end object");
        }
        
        return linkList;
    }

    public override void Write(Utf8JsonWriter writer, LinkList value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        value.ForEach(x =>
        {
            writer.WritePropertyName(x.Name);
            writer.WriteStringValue(x.Url);
        });
        writer.WriteEndObject();
    }
}