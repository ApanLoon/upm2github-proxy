using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using upm2github_proxy.Models.Upm;

namespace upm2github_proxy.Models.Npm;

public class PackageVersion : AbbreviatedMetadata
{
    /// <summary>
    /// package@version, such as npm@1.0.0
    /// </summary>
    [JsonPropertyName("_from")] public string? From { get; set; }
    [JsonPropertyName("_id")] public string? Id { get; set; }
    [JsonPropertyName("_nodeVersion")] public string? NodeVersion { get; set; }
    [JsonPropertyName("_npmUser")] public Human? NpmUser { get; set; }
    [JsonPropertyName("_npmVersion")] public string? NpmVersion { get; set; }
    [JsonPropertyName("_shasum")] public string? ShaSum { get; set; }
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

    #region GitHub
    [JsonPropertyName("gitHead")] public string? GitHead { get; set; }
    #endregion GitHub

    public Upm.PackageVersion AsUpm()
    {
        var name = PackageMetadata.NameAsUpm(Name);
        return new Upm.PackageVersion
        {
            Name           = name,
            Version        = this.Version,
            DisplayName    = name,
            Description    = this.Description,
            Unity          = "", // TODO: How to get this?
            UnityRelease   = "", // TODO: How to get this?
            //Dependencies = ?? TODO: How to get this?
            Keywords       = this.Keywords,
            Author         = this.Author?.AsUpm(),
            PublishConfig  = new Dictionary<string, string>(), // TODO: How to get this?
            GitHead        = this.GitHead,
            ReadmeFilename = this.ReadmeFilename,
            Id             = this.Id,
            NodeVersion    = this.NodeVersion,
            NpmUser        = this.NpmUser?.AsUpm(),
            Maintainers    = this.MaintainersAsUpm(),
            Dist           = this.Dist?.AsUpm(),
            Contributors   = this.ContributorsAsUpm()
        };
    }

    private List<Contact>? ContributorsAsUpm()
    {
        var contributors = Contributors ?? new List<Human>();
        return contributors?.Select(contributor => contributor.AsUpm()).ToList();
    }

    public List<Contact>? MaintainersAsUpm()
    {
        var maintainers = Maintainers ?? new List<Human>();
        return maintainers?.Select(contributor => contributor.AsUpm()).ToList();
    }
}
