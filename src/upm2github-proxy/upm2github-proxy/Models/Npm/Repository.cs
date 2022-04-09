using System.Text.Json.Serialization;

namespace upm2github_proxy.Models.Npm;

public class Repository
{
    public Repository(string repositoryType, string url)
    {
        RepositoryType = repositoryType;
        Url = url;
    }

    [JsonPropertyName("type")] public string RepositoryType { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }

    public Upm.Repository AsUpm()
    {
        return new Upm.Repository()
        {
            Type = this.RepositoryType,
            Url = this.Url
        };
    }
}