using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using upm2github_proxy.Authentication;
using upm2github_proxy.Models.Npm;
using upm2github_proxy.Models.Upm;
using upm2github_proxy.Services.GitHub.Model;

namespace upm2github_proxy.Services.GitHub;

class GitHubRegistryService : IRegistryService
{
    private readonly IAuthDictionary _authDictionary;
    private readonly HttpClient _gitHubHttpClient;
    private readonly HttpClient _npmClient;

    public GitHubRegistryService(IAuthDictionary authDictionary)
    {
        _authDictionary = authDictionary;
        _gitHubHttpClient = new HttpClient();
        
        _gitHubHttpClient.DefaultRequestHeaders.Host = "api.github.com";
        
        _gitHubHttpClient.DefaultRequestHeaders.UserAgent.Clear();
        _gitHubHttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("upm2github-proxy", "1.0"));

        _gitHubHttpClient.DefaultRequestHeaders.Accept.Clear();
        _gitHubHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        
        _npmClient = new HttpClient();

        _gitHubHttpClient.DefaultRequestHeaders.UserAgent.Clear();
        _gitHubHttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("upm2github-proxy", "1.0"));

    }
    public async Task<SearchResult> Search (
        string scope = "",
        string text = "",
        int size = 20,
        int @from = 0,
        float quality = 1f,
        float popularity = 0f,
        float maintenance = 0f,
        string username = "")
    {
        var token = _authDictionary.GetToken(username);
        var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{token}")));

        _gitHubHttpClient.DefaultRequestHeaders.Authorization = authHeader;
        var body = await _gitHubHttpClient.GetStringAsync($"https://api.github.com/users/{username}/packages?package_type=npm");

        var result = new SearchResult();
        var packageList = JsonSerializer.Deserialize<PackageListItem[]>(body);
        if (packageList == null)
        {
            return result;
        }

        _npmClient.DefaultRequestHeaders.Authorization = authHeader;
        foreach (var packageListItem in packageList)
        {
            body = await _npmClient.GetStringAsync($"https://npm.pkg.github.com/@{username}/{packageListItem.Name}");
            var packageInfo = JsonSerializer.Deserialize<PackageMetadata> (body) ?? new PackageMetadata();
            var searchResultEntry = new SearchResultEntry()
            {
                Package = packageInfo.AsUpm(),
                Flags = new Dictionary<string, bool>{{"unstable", false}},
                Local = false,
                Score = new Score()
                {
                    Final = 1,
                    Detail = new ScoreDetail()
                    {
                        Quality = 1,
                        Maintenance = 1,
                        Popularity = 1
                    }
                },
                SearchScore = 100000
            };
            result.Add(searchResultEntry);

        }
        return result;
    }

    public PackageHistory History(string name, string scope = "")
    {
        var result = new PackageHistory();
        return result;
    }
}