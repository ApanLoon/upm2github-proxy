using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using upm2github_proxy.Json;
using upm2github_proxy.Models;
using upm2github_proxy.Models.Upm;

namespace upm2github_proxy.Services;

public class MockRegistryService : IRegistryService
{
    private string _searchResult = @"
{
  ""objects"": [
    {
      ""package"": {
        ""name"": ""com.apanloon.test-package"",
        ""displayName"": ""Apans Test Package"",
        ""description"": ""This package was created to test of packages are made"",
        ""dist-tags"": {
          ""latest"": ""0.0.1""
        },
        ""maintainers"": [
          {
            ""name"": ""Apan Loon"",
            ""url"": ""https://github.com/ApanLoon""
          }
        ],
        ""author"": {
          ""name"": ""Apan Loon"",
          ""url"": ""https://github.com/ApanLoon""
        },
        ""repository"": {
          ""type"": ""git"",
          ""url"": ""git+ssh://git@github.com/ApanLoon/unitypackage-test.git""
        },
        ""readmeFilename"": ""README.md"",
        ""keywords"": [
          ""test""
        ],
        ""time"": {
          ""modified"": ""2022-03-18T04:13:39.253Z""
        },
        ""versions"": {
          ""0.0.1"": ""latest""
        }
      },
      ""flags"": {
        ""unstable"": false
      },
      ""local"": false,
      ""score"": {
        ""final"": 1,
        ""detail"": {
          ""quality"": 1,
          ""popularity"": 1,
          ""maintenance"": 0
        }
      },
      ""searchScore"": 100000
    }
  ],
  ""total"": 1,
  ""time"": ""Wed, 16 Mar 2022 22:57:02 GMT""
}";

    private readonly string _packageHistory = @"
{
    ""name"": ""com.apanloon.test-package"",
    ""versions"": 
    {
        ""0.0.1"": 
        {
            ""name"": ""com.apanloon.test-package"",
            ""version"": ""0.0.1"",
            ""displayName"": ""Apans Test Package"",
            ""description"": ""This package was created to test of packages are made"",
            ""unity"": ""2020.3"",
            ""unityRelease"": ""30f1"",
            ""documentationUrl"": ""https://github.com/ApanLoon/unitypackage-test/wiki"",
            ""licensesUrl"": ""https://github.com/ApanLoon/unitypackage-test/blob/main/LICENSE"",
            ""keywords"": [
                ""test""
            ],
            ""author"": {
                ""name"": ""Apan Loon"",
                ""url"": ""https://github.com/ApanLoon""
            },
            ""repository"": ""https://github.com/ApanLoon/unitypackage-test"",
            ""publishConfig"": {
                ""registry"": ""https://npm.pkg.github.com/""
            }
        }
    },
    ""time"": 
    {
      ""modified"": ""2022-03-18T04:13:39.253Z"",
      ""created"": ""2022-03-15T04:09:48.058Z"",
      ""0.0.9"": ""2022-03-18T04:09:48.058Z""
    },
    ""users"": {},
    ""dist-tags"": {
      ""latest"": ""0.0.1""
    },
    ""_rev"": ""27-927fd6c90e173141"",
    ""_id"": ""com.apanloon.test-package"",
    ""readme"": ""# unitypackage-test\nTesting how to make a unity package\n\nThis package contains a MonoBehaviour, TestPackageBehaviour, that simply reports its Start and a texture that isn't even perfect."",
    ""_attachments"": {}
}";

    public Task<SearchResult> Search(string scope = "",
        string text = "",
        [Range(0, 250)] int size = 20,
        int @from = 0,
        [Range(0f, 1f)] float quality = 1F,
        [Range(0f, 1f)] float popularity = 0F,
        [Range(0f, 1f)] float maintenance = 0F,
        string username = "")
    {
        var result = JsonSerializer.Deserialize<SearchResult>(_searchResult, ApplicationJsonOptions.SerializerOptions)
                     ?? throw new HttpRequestException("Error searching for packages", null, HttpStatusCode.InternalServerError);
        
        if (from >= result.Objects.Count)
        {
            from = 0;
            size = 0;
        }

        if (from + size >= result.Objects.Count)
        {
            size = result.Objects.Count - from;
        }

        result = new SearchResult()
        {
            Objects = result.Objects.Take(new Range(from, size)).ToList(),
            Time = DateTimeOffset.Now
        };
        return Task.FromResult(result);
    }

    public PackageHistory History (string name, string scope = "")
    {
        var result = JsonSerializer.Deserialize<PackageHistory>(_packageHistory, ApplicationJsonOptions.SerializerOptions)
                     ?? throw new HttpRequestException("Error loading package history", null, HttpStatusCode.InternalServerError);
        return result;
    }
}