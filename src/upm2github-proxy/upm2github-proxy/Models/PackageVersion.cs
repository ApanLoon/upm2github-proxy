using System.Security;
using System.Text.Json.Serialization;

namespace upm2github_proxy.Models;

public class PackageVersion
{
    public string Name { get; set; }
    
    public string Version { get; set; }
    
    public string DisplayName { get; set; }
    
    public string Description { get; set; }
    
    public string Unity { get; set; }
    
    public string UnityRelease { get; set; }
    
    public List<string> Dependencies { get; set; } // TODO: What type is this?
    
    public List<string> Keywords { get; set; }
    
    public Contact Author { get; set; }
    
    public Dictionary<string, string> PublishConfig { get; set; }
    
    public string GitHead { get; set; }
    
    public string ReadmeFilename { get; set; }
    
    [JsonPropertyName("_id")]
    public string Id { get; set; }
    
    [JsonPropertyName("_nodeVersion")]
    public string NodeVersion { get; set; }
    
    [JsonPropertyName("_npmUser")]
    public Contact NpmUser { get; set; }

    public List<Contact> Maintainers { get; set; }

    public Dictionary<string, string> Dist { get; set; }

    public List<Contact> Contributors { get; set; }
}