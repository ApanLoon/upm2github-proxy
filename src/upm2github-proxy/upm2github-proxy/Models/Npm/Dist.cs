using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace upm2github_proxy.Models.Npm;

public class Dist
{
    public Dist(string tarball, string shaSum)
    {
        Tarball = tarball;
        ShaSum = shaSum;
    }

    [JsonPropertyName("tarball")] public string Tarball { get; set; }
    [JsonPropertyName("shasum")] public string ShaSum { get; set; }
    [JsonPropertyName("integrity")] public string? Integrity { get; set; }
    [JsonPropertyName("fileCount")] public int? FileCount { get; set; }
    [JsonPropertyName("unpackedSize")] public int? UnpackedSize { get; set; }
    [JsonPropertyName("npm-signature")] public string? NpmSignature { get; set; }

    public Dictionary<string, string> AsUpm()
    {
        var match = Regex.Match(Tarball, "^https?://[^/]+/download/@([^/]+)/(.+)$");
        var tarball = $"http://localhost:5080/user/{match.Groups[1].Value}/download/{HttpUtility.UrlEncode(match.Groups[2].Value, Encoding.ASCII)}"; // TODO: Get method, host and port from somewhere
        var result = new Dictionary<string, string>
        {
            {"tarball", tarball},
            {"shasum", ShaSum}
        };
        if (Integrity != null) result.Add("integrity", Integrity);
        if (FileCount != null) result.Add("fileCount", FileCount.ToString());
        if (UnpackedSize != null) result.Add("unpackedSize", UnpackedSize.ToString());
        if (NpmSignature != null) result.Add("npm-signature", NpmSignature);
        return result;
    }
}