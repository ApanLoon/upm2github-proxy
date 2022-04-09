using System.Text.Json.Serialization;
using upm2github_proxy.Models.Upm;

namespace upm2github_proxy.Models.Npm;

public class Human
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }

    public Contact AsUpm()
    {
        return new Contact()
        {
            Name = this.Name,
            Email = this.Email,
            Url = this.Url
        };
    }
}