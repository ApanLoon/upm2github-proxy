﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using upm2github_proxy.Models.Upm;
using upm2github_proxy.Services;

namespace upm2github_proxy.Controllers
{
    [ApiController]
    public class UpmController : ControllerBase
    {
        private readonly IRegistryService _registryService;
        private readonly ILogger<UpmController> _logger;

        public UpmController(IRegistryService registryService, ILogger<UpmController> logger)
        {
            _registryService = registryService;
            _logger = logger;
        }

        /// <summary>
        /// Search for packages.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="text">Full-text search to apply</param>
        /// <param name="size">How many results should be returned (default 20, max 250)</param>
        /// <param name="from">Offset to return results from</param>
        /// <param name="quality">How much of an effect should quality have on search results</param>
        /// <param name="popularity">How much of an effect should popularity have on search results</param>
        /// <param name="maintenance">How much of an effect should maintenance have on search results</param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{username}/-/v1/search")]
        public async Task<SearchResult> Search (
                                       string username    = "",
            [FromQuery]                string text        = "",
            [FromQuery][Range(0, 250)] int    size        = 20,
            [FromQuery]                int    from        = 0,
            [FromQuery][Range(0f, 1f)] float  quality     = 1f,
            [FromQuery][Range(0f, 1f)] float  popularity  = 0f,
            [FromQuery][Range(0f, 1f)] float  maintenance = 0f)
        {
            _logger.LogDebug("GET user/{username}/-/v1/search?text={text}&size={size}&from={@from}&quality={quality}&popularity={popularity}&maintenance={maintenance}", username, text, size, from, quality, popularity, maintenance);
            return await _registryService.Search("", text, size, @from, quality, popularity, maintenance, username);
        }

        [HttpGet]
        [Route("user/{username}/{packageName}")]
        public async Task<PackageHistory> PackageHistory(string username, string packageName)
        {
            _logger.LogDebug("GET user/{username}/{name}", username, packageName);
            return await _registryService.History(packageName, username);
        }
    }
}
