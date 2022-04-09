using System.Text.Json.Serialization;
using upm2github_proxy.Json;

namespace upm2github_proxy.Models.Upm
{
    [JsonConverter(typeof(LinkListJsonConverter))]
    public class LinkList : List<Link>
    {
    }
}
