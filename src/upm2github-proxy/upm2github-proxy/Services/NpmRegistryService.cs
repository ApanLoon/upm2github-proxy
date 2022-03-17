using System.ComponentModel.DataAnnotations;
using upm2github_proxy.Models;

namespace upm2github_proxy.Services
{
    public class NpmRegistryService : IRegistryService
    {
        public SearchResult Search (
            string text = "",
            [Range(0, 250)] int size = 20,
            int from = 0,
            [Range(0f, 1f)] float quality = 1f,
            [Range(0f, 1f)] float popularity = 0f,
            [Range(0f, 1f)] float maintenance = 0f)
        {
            var data = new SearchResult()
            {
                Objects = new List<SearchResultEntry>(),
                Time = DateTime.Now
            };
            return data;
        }
    }
}
