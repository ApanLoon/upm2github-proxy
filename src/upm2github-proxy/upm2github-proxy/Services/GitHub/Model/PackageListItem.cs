using System.Text.Json.Serialization;

namespace upm2github_proxy.Services.GitHub.Model
{
    public class PackageListItem
    {
        [JsonPropertyName("id")] public int Id { get; set; } = 0;
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

        [JsonPropertyName("package_type")] public string PackageType { get; set; } = String.Empty;

        [JsonPropertyName("owner")] public Account Owner { get; set; } = new Account();

        [JsonPropertyName("version_count")] public int VersionCount { get; set; } = 0;

        [JsonPropertyName("visibility")] public string Visibility { get; set; } = string.Empty;

        [JsonPropertyName("url")] public string Url { get; set; } = String.Empty;

        [JsonPropertyName("created_at")] public string CreatedAt { get; set; } = String.Empty;

        [JsonPropertyName("updated_at")] public string UpdatedAt { get; set; } = String.Empty;

        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; } = String.Empty;
    }
}
