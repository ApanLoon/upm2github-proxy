using System.Text.Json.Serialization;

namespace upm2github_proxy.Models
{
    public class Package
    {
        public string Name { get; set; } = "";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }

        [JsonPropertyName("dist-tags")]
        public Dictionary<string, string>? DistTags { get; set; }
        public List<Contact>? Maintainers { get; set; }
        public Contact? Author { get; set; }
        public Repository? Repository { get; set; }

        public string? ReadmeFilename { get; set; }
        public string? Homepage { get; set; }
        public List<string>? Keywords { get; set; }
        public Contact? Bugs { get; set; }
        public string? License { get; set; }
        public TimeInfo? Time { get; set; }
        public Dictionary<string, string>? Versions { get; set; }
    }
}
