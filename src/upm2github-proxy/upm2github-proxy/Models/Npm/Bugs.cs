using System.Text.Json.Serialization;

namespace upm2github_proxy.Models.Npm;

public class Bugs
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}