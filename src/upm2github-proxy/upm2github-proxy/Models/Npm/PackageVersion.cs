using System.Text.Json.Serialization;

namespace upm2github_proxy.Models.Npm;

public class PackageVersion : AbbreviatedMetadata
{
    /// <summary>
    /// package@version, such as npm@1.0.0
    /// </summary>
    [JsonPropertyName("_id")] public string? Id { get; set; }
    [JsonPropertyName("_nodeVersion")] public string? NodeVersion { get; set; }
    [JsonPropertyName("_npmUser")] public Human? NpmUser { get; set; }
    [JsonPropertyName("_npmVersion")] public string? NpmVersion { get; set; }
    [JsonPropertyName("main")] public string? Main { get; set; }

    [JsonPropertyName("author")] public Human? Author { get; set; }
    [JsonPropertyName("bugs")] public Bugs? Bugs { get; set; }
    [JsonPropertyName("contributors")] public List<Human>? Contributors { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("homepage")] public string? Homepage { get; set; }
    [JsonPropertyName("keywords")] public List<string>? Keywords { get; set; }
    [JsonPropertyName("license")] public string? License { get; set; }
    [JsonPropertyName("maintainers")] public List<Human>? Maintainers { get; set; }
    [JsonPropertyName("readme")] public string? Readme { get; set; }
    [JsonPropertyName("readmeFilename")] public string? ReadmeFilename { get; set; }
    [JsonPropertyName("repository")] public Repository? Repository { get; set; }
}
