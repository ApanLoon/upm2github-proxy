using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using upm2github_proxy.Json;
using upm2github_proxy.Models;

namespace UnitTests.Serialization
{
    public class SearchResultTests
    {
        private readonly string result0_json = "{\"objects\":[{\"package\":{\"name\":\"com.gemserk.upmgitpusher\",\"displayName\":\"UnityPackageManagerGitPusher\",\"description\":\"Just a simple tool integrated to Unity to publish your packages in a way UPM supports\",\"dist-tags\":{\"latest\":\"0.0.16\"},\"maintainers\":[{\"name\":\"openupm\",\"email\":\"openupm\"}],\"author\":{\"name\":\"Ariel Coppes\",\"email\":\"ariel.coppes@gmail.com\",\"url\":\"https://blog.gemserk.com\"},\"repository\":{\"type\":\"git\",\"url\":\"git+ssh://git@github.com/acoppes/upmgitpusher.git\"},\"readmeFilename\":\"README.md\",\"homepage\":\"https://github.com/acoppes/upmgitpusher\",\"keywords\":[\"git\",\"tools\",\"publish\",\"package\",\"upm\"],\"bugs\":{\"url\":\"https://github.com/acoppes/upmgitpusher/issues\"},\"time\":{\"modified\":\"2020-04-26T04:13:39.253Z\"},\"versions\":{\"0.0.16\":\"latest\"}},\"flags\":{\"unstable\":true},\"local\":true,\"score\":{\"final\":1,\"detail\":{\"quality\":1,\"popularity\":1,\"maintenance\":0}},\"searchScore\":100000}],\"total\":1,\"time\":\"2022-03-16T22:57:02Z\"}";
        private readonly SearchResult result0 = new()
        {
            Objects = new List<SearchResultEntry>
            {
                new SearchResultEntry
                {
                    Package = new()
                    {
                        Name = "com.gemserk.upmgitpusher",
                        DisplayName = "UnityPackageManagerGitPusher",
                        Description = "Just a simple tool integrated to Unity to publish your packages in a way UPM supports",
                        DistTags = new Dictionary<string, string>
                        {
                            {"latest", "0.0.16"}
                        },
                        Maintainers = new List<Contact>
                        {
                            new() { Name = "openupm", Email = "openupm"}
                        },
                        Author = new Contact
                        {
                            Name = "Ariel Coppes",
                            Email = "ariel.coppes@gmail.com",
                            Url = "https://blog.gemserk.com"
                        },
                        Repository = new Repository
                        {
                            Type = "git",
                            Url = "git+ssh://git@github.com/acoppes/upmgitpusher.git"
                        },
                        ReadmeFilename = "README.md",
                        Homepage = "https://github.com/acoppes/upmgitpusher",
                        Keywords = new List<string>
                        {
                            "git",
                            "tools",
                            "publish",
                            "package",
                            "upm"
                        },
                        Bugs = new Contact
                        {
                            Url = "https://github.com/acoppes/upmgitpusher/issues"
                        },
                        Time = new TimeInfo
                        {
                            Modified = DateTimeOffset.Parse("2020-04-26T04:13:39.253Z")
                        },
                        Versions = new Dictionary<string, string>
                        {
                            {"0.0.16", "latest"}
                        }
                    },
                    Flags = new Dictionary<string, bool>
                    {
                        { "unstable", true }
                    },
                    Local = true,
                    Score = new Score
                    {
                        Final = 1,
                        Detail = new ScoreDetail
                        {
                            Quality = 1,
                            Popularity = 1,
                            Maintenance = 0
                        }
                    },
                    SearchScore = 100000
                }
            },
            //Total = 1, // Total is a read-only property
            Time = DateTimeOffset.Parse("Wed, 16 Mar 2022 22:57:02 GMT") // NOTE: This date format is not the same as the one used in the json string, but it still evaluates to the same, works in both directions
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeserializeResult0()
        {
            var result = JsonSerializer.Deserialize<SearchResult>(result0_json, ApplicationJsonOptions.SerializerOptions);
            Assert.IsNotNull(result);
            Assert.AreEqual(result0.Total, result!.Total);
            Assert.AreEqual(result0.Time, result.Time);
            Assert.Pass();
        }

        [Test]
        public void SerializeResult0()
        {
            var s = JsonSerializer.Serialize(result0, ApplicationJsonOptions.SerializerOptions);
            Assert.AreEqual(result0_json, Helpers.UnEscapeUnicode(s));
            Assert.Pass();
        }
    }
}
