using System.Text.Json.Serialization;

namespace upm2github_proxy.Models.Npm;

public class AbbreviatedMetadata
{
    [JsonPropertyName("name")]                 public string Name { get; set; } = "";
    [JsonPropertyName("version")]              public string Version { get; set; } = "";
    [JsonPropertyName("deprecated")]           public string? Deprecated { get; set; } = "";
    [JsonPropertyName("dependencies")]         public Dictionary<string, string>? Dependencies { get; set; }
    [JsonPropertyName("optionalDependencies")] public Dictionary<string, string>? OptionalDependencies { get; set; }
    [JsonPropertyName("devDependencies")]      public Dictionary<string, string>? DevDependencies { get; set; }
    [JsonPropertyName("bundleDependencies")]   public Dictionary<string, string>? BundleDependencies { get; set; }
    [JsonPropertyName("peerDependencies")]     public Dictionary<string, string>? PeerDependencies { get; set; }
    [JsonPropertyName("bin")]                  public Dictionary<string, string>? Bin { get; set; }
    [JsonPropertyName("directories")]          public Dictionary<string, string>? Directories { get; set; }
    [JsonPropertyName("dist")]                 public Dist? Dist { get; set; }
    [JsonPropertyName("engines")]              public string? Engines { get; set; }
    [JsonPropertyName("_hasShrinkWrap")]       public bool? HasShrinkWrap { get; set; }
}