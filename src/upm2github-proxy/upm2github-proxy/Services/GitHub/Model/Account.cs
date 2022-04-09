using System.Text.Json.Serialization;

namespace upm2github_proxy.Services.GitHub.Model;

public class Account
{
    [JsonPropertyName("login")] public string Login { get; set; } = String.Empty;
    [JsonPropertyName("id")] public int Id { get; set; } = 0;
    [JsonPropertyName("node_id")] public string NodeId { get; set; } = String.Empty;
    [JsonPropertyName("avatar_url")] public string AvatarUrl { get; set; } = String.Empty;
    [JsonPropertyName("gravatar_id")] public string GravatarId { get; set; } = String.Empty;
    [JsonPropertyName("url")] public string Url { get; set; } = String.Empty;
    [JsonPropertyName("html_url")] public string HtmlUrl { get; set; } = String.Empty;
    [JsonPropertyName("followers_url")] public string FollowersUrl { get; set; } = String.Empty;
    [JsonPropertyName("following_url")] public string FollowingUrl { get; set; } = String.Empty;
    [JsonPropertyName("gists_url")] public string GistsUrl { get; set; } = String.Empty;
    [JsonPropertyName("starred_url")] public string StarredUrl { get; set; } = String.Empty;
    [JsonPropertyName("subscriptions_url")] public string SubscriptionsUrl { get; set; } = String.Empty;
    [JsonPropertyName("organizations_url")] public string OrganizationsUrl { get; set; } = String.Empty;
    [JsonPropertyName("repos_url")] public string ReposUrl { get; set; } = String.Empty;
    [JsonPropertyName("events_url")] public string EventsUrl { get; set; } = String.Empty;
    [JsonPropertyName("received_events_url")] public string ReceivedEventsUrl { get; set; } = String.Empty;
    [JsonPropertyName("type")] public string AccountType { get; set; } = String.Empty;
    [JsonPropertyName("site_admin")] public bool IsSiteAdmin { get; set; } = false;
}