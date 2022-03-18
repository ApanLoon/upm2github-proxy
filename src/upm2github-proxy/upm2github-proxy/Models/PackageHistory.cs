using System.Text.Json.Serialization;

namespace upm2github_proxy.Models
{
    public class PackageHistory
    {
        public string Name { get; set; }
        
        public Dictionary<string, PackageVersion> Versions { get; set; }
        
        public Dictionary<string, DateTimeOffset> Time { get; set; }
        
        public Dictionary<string, string> Users { get; set; } // TODO: What type is this?

        [JsonPropertyName("dist_tags")]
        public Dictionary<string, string> DistTags { get; set; }
        
        [JsonPropertyName("_rev")]
        public string Rev { get; set; }
        
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        
        public string Readme { get; set; }
        
        [JsonPropertyName("_attachments")]
        public Dictionary<string, string> Attachments { get; set; } // TODO: What type is this?
    }
}
