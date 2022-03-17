using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Semver;
using upm2github_proxy.Models;
using upm2github_proxy.Services;

namespace upm2github_proxy.Controllers
{
    [ApiController]
    [Route("-/v1")]
    public class UpmController : ControllerBase
    {
        private readonly IRegistryService _registryService;

        public UpmController(IRegistryService registryService) => _registryService = registryService;

        /// <summary>
        /// Search for packages.
        /// </summary>
        /// <param name="text">Full-text search to apply</param>
        /// <param name="size">How many results should be returned (default 20, max 250)</param>
        /// <param name="from">Offset to return results from</param>
        /// <param name="quality">How much of an effect should quality have on search results</param>
        /// <param name="popularity">How much of an effect should popularity have on search results</param>
        /// <param name="maintenance">How much of an effect should maintenance have on search results</param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        public SearchResult Search (
            [FromQuery]                string text        = "*",
            [FromQuery][Range(0, 250)] int    size        = 20,
            [FromQuery]                int    from        = 0,
            [FromQuery][Range(0f, 1f)] float  quality     = 1f,
            [FromQuery][Range(0f, 1f)] float  popularity  = 0f,
            [FromQuery][Range(0f, 1f)] float  maintenance = 0f)
        {
            return _registryService.Search(text, size, from, quality, popularity, maintenance);
        }
    }
}
