namespace upm2github_proxy.Models;

public class SearchResult
{
    public List<SearchResultEntry> Objects { get; set; } = new List<SearchResultEntry>();
    public int Total => Objects.Count;
    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
}