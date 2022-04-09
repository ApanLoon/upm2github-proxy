namespace upm2github_proxy.Models.Upm;

public class SearchResult
{
    public List<SearchResultEntry> Objects { get; set; } = new();
    public int Total => Objects.Count;
    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

    public void Clear()
    {
        Objects.Clear();
    }

    public void Add(SearchResultEntry searchResultEntry)
    {
        Objects.Add(searchResultEntry);
    }
}
