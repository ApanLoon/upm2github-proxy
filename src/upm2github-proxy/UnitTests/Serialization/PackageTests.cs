using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using upm2github_proxy.Json;
using upm2github_proxy.Models.Upm;

namespace UnitTests.Serialization;

public class PackageTests
{
    private readonly (string Json, Package Package)[] _packages = 
    {
        (
            "{\"name\":\"com.gemserk.upmgitpusher\",\"displayName\":\"UnityPackageManagerGitPusher\",\"description\":\"Just a simple tool integrated to Unity to publish your packages in a way UPM supports\",\"dist-tags\":{\"latest\":\"0.0.16\"},\"maintainers\":[{\"name\":\"openupm\",\"email\":\"openupm\"}],\"author\":{\"name\":\"Ariel Coppes\",\"email\":\"ariel.coppes@gmail.com\",\"url\":\"https://blog.gemserk.com\"},\"repository\":{\"type\":\"git\",\"url\":\"git+ssh://git@github.com/acoppes/upmgitpusher.git\"},\"readmeFilename\":\"README.md\",\"homepage\":\"https://github.com/acoppes/upmgitpusher\",\"keywords\":[\"git\",\"tools\",\"publish\",\"package\",\"upm\"],\"bugs\":{\"url\":\"https://github.com/acoppes/upmgitpusher/issues\"},\"time\":{\"modified\":\"2020-04-26T04:13:39.253Z\"},\"versions\":{\"0.0.16\":\"latest\"}}",
            new()
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
                Bugs = new Bugs
                {
                    Url = "https://github.com/acoppes/upmgitpusher/issues"
                },
                Time = new Dictionary<string, DateTimeOffset>
                {
                    {"modified", DateTimeOffset.Parse("2020-04-26T04:13:39.253Z")}
                },
                Versions = new Dictionary<string, string>
                {
                    {"0.0.16", "latest"}
                }
            }
        ),
        (
            "{\"name\":\"com.wayngroup.stm\",\"displayName\":\"Script Template Manager\",\"description\":\"A unity editor extension that allow you to create and manage your own script templates.\",\"dist-tags\":{\"latest\":\"0.0.5-alpha\"},\"maintainers\":[{\"name\":\"openupm\",\"email\":\"openupm\"}],\"readmeFilename\":\"README.md\",\"keywords\":[\"script\",\"c#\",\"template\"],\"time\":{\"modified\":\"2021-05-03T08:11:07.176Z\"},\"versions\":{\"0.0.5-alpha\":\"latest\"}}", 
            new Package
            {
                Name = "com.wayngroup.stm",
                DisplayName = "Script Template Manager",
                Description = "A unity editor extension that allow you to create and manage your own script templates.",
                DistTags = new Dictionary<string, string>
                {
                    { "latest", "0.0.5-alpha" }
                },
                Maintainers = new List<Contact>
                {
                    new() { Name = "openupm", Email = "openupm" }
                },
                ReadmeFilename = "README.md",
                Keywords = new List<string>
                {
                    "script",
                    "c#",
                    "template"
                },
                Time = new Dictionary<string, DateTimeOffset>
                {
                    {"modified", DateTimeOffset.Parse("2021-05-03T08:11:07.176Z")}
                },
                Versions = new Dictionary<string, string>
                {
                    { "0.0.5-alpha", "latest" }
                }
            }
        ),
        (
            "{\"name\":\"com.andrewraphaellukasik.iopaths\",\"displayName\":\"IO Paths\",\"description\":\"Utility structures to help working with file paths in Unity.\",\"dist-tags\":{\"latest\":\"0.0.1\"},\"maintainers\":[{\"name\":\"openupm\",\"email\":\"openupm\"}],\"author\":{\"name\":\"Andrzej Rafał Łukasik\",\"email\":\"andrew.r.lukasik@gmail.com\",\"url\":\"https://github.com/andrew-raphael-lukasik\"},\"readmeFilename\":\"\",\"time\":{\"modified\":\"2020-11-05T18:51:58.362Z\"},\"versions\":{\"0.0.1\":\"latest\"}}",
            new Package
            {
                Name = "com.andrewraphaellukasik.iopaths",
                DisplayName = "IO Paths",
                Description = "Utility structures to help working with file paths in Unity.",
                DistTags = new Dictionary<string, string>
                {
                    { "latest", "0.0.1" }
                },
                Maintainers = new List<Contact>
                {
                    new() { Name = "openupm", Email = "openupm" }
                },
                Author = new Contact
                {
                    Name = "Andrzej Rafał Łukasik",
                    Email = "andrew.r.lukasik@gmail.com",
                    Url = "https://github.com/andrew-raphael-lukasik"
                },
                ReadmeFilename = "",
                Time = new Dictionary<string, DateTimeOffset>
                {
                    {"modified", DateTimeOffset.Parse("2020-11-05T18:51:58.362Z")}
                },
                Versions = new Dictionary<string, string>
                {
                    { "0.0.1", "latest" }
                }
            }
        )
    };

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SerializePackages()
    {
        foreach (var (json, package) in _packages)
        {
            var s = JsonSerializer.Serialize(package, ApplicationJsonOptions.SerializerOptions);
            Assert.AreEqual(json, Helpers.UnEscapeUnicode(s));
        }
        Assert.Pass();
    }
}