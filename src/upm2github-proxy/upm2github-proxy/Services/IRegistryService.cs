using System.ComponentModel.DataAnnotations;
using upm2github_proxy.Models.Upm;

namespace upm2github_proxy.Services;

public interface IRegistryService
{
    public Task<SearchResult> Search(string scope = "",
        string text = "",
        [Range(0, 250)] int size = 20,
        int @from = 0,
        [Range(0f, 1f)] float quality = 1F,
        [Range(0f, 1f)] float popularity = 0F,
        [Range(0f, 1f)] float maintenance = 0F,
        string username = "");

    public Task<PackageHistory> History(string name, string username = "");
    public Task<HttpResponseMessage> Download(string package, string username);
}