using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using upm2github_proxy.Models.Upm;

namespace upm2github_proxy.Models.Npm
{
    public class PackageMetadata
    {
        [JsonPropertyName("_id")] public string Id { get; set; } = "";
        [JsonPropertyName("_rev")] public string? Rev { get; set; } = "";
        [JsonPropertyName("dist-tags")] public Dictionary<string, string>? DistTags { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; } = "";
        [JsonPropertyName("time")] public Dictionary<string, string>? Time { get; set; }
        [JsonPropertyName("users")] public Dictionary<string, string>? Users { get; set; }
        [JsonPropertyName("versions")] public Dictionary<string, PackageVersion>? Versions { get; set; }
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

        // TODO: It is possible that this object contains other info from the package.json of the package
        
        /// <summary>
        /// Creates a versions dictionary as used in UPM from this PackageMetadata.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string>? VersionsAsUpm()
        {
            return DistTags?.ToDictionary(distTag => distTag.Value, distTag => distTag.Key);
        }

        public List<Contact>? MaintainersAsUpm()
        {
            var maintainers = Maintainers ?? this.Versions?.FirstOrDefault().Value.Maintainers ?? new List<Human>();
            return maintainers?.Select(contributor => contributor.AsUpm()).ToList();
        }

        public Upm.Bugs BugsAsUpm()
        {
            return new Upm.Bugs { Url = Bugs?.Url ?? this.Versions?.FirstOrDefault().Value.Bugs?.Url };
        }

        public Dictionary<string, DateTimeOffset>? TimeAsUpm()
        {
            return Time?.ToDictionary(time => time.Key, time => DateTimeOffset.Parse(time.Value));
        }

        public Package AsUpm()
        {
            var name = Regex.Replace(Name, "^[^/]*/", "");
            return new Package
            {
                Name           = name,
                DisplayName    = name,
                Description    = this.Description,
                DistTags       = this.DistTags,
                Maintainers    = this.MaintainersAsUpm(),
                Author         = this.Author?.AsUpm()     ?? this.Versions?.FirstOrDefault().Value?.Author?.AsUpm(),
                Repository     = this.Repository?.AsUpm() ?? this.Versions?.FirstOrDefault().Value.Repository?.AsUpm(),
                ReadmeFilename = this.ReadmeFilename      ?? this.Versions?.FirstOrDefault().Value.ReadmeFilename ?? "",
                Homepage       = this.Homepage            ?? this.Versions?.FirstOrDefault().Value.Homepage,
                Keywords       = this.Keywords            ?? this.Versions?.FirstOrDefault().Value.Keywords ?? new List<string>(),
                Bugs           = this.BugsAsUpm(),
                License        = this.License             ?? this.Versions?.FirstOrDefault().Value.License,
                Time           = this.TimeAsUpm(),
                Versions       = this.VersionsAsUpm()
            };
        }
    }
}
