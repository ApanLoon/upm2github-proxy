using System.Text.Json;
using NUnit.Framework;
using upm2github_proxy.Json;
using upm2github_proxy.Models.Upm;

namespace UnitTests.Serialization
{
    public class LinkListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private readonly string _normalJson = "{\"npm\":\"https://www.npmjs.com/package/yargs\",\"homepage\":\"http://yargs.js.org/\",\"repository\":\"https://github.com/yargs/yargs\",\"bugs\":\"https://github.com/yargs/yargs/issues\"}";
        private readonly LinkList _normalList = new LinkList
        {
            new() { Name = "npm",        Url = "https://www.npmjs.com/package/yargs" },
            new() { Name = "homepage",   Url = "http://yargs.js.org/" },
            new() { Name = "repository", Url = "https://github.com/yargs/yargs" },
            new() { Name = "bugs",       Url = "https://github.com/yargs/yargs/issues" }
        };

        [Test]
        public void SerializeNormal()
        {
            var s = JsonSerializer.Serialize(_normalList, ApplicationJsonOptions.SerializerOptions);
            Assert.AreEqual(_normalJson, Helpers.UnEscapeUnicode(s));
            Assert.Pass();
        }

        [Test]
        public void DeserializeNormal()
        {
            var linkList = JsonSerializer.Deserialize<LinkList>(_normalJson, ApplicationJsonOptions.SerializerOptions);
            Assert.IsNotNull(linkList);
            Assert.AreEqual(_normalList.Count, linkList!.Count);
            for (var i = 0; i < linkList.Count; i++)
            {
                Assert.AreEqual(linkList[i].Name, _normalList[i].Name);
                Assert.AreEqual(linkList[i].Url, _normalList[i].Url);
            }
            Assert.Pass();
        }

        // TODO: Add error cases
    }
}