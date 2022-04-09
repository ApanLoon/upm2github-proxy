namespace upm2github_proxy.Models.Upm
{
    public class SearchResultEntry
    {
        public Package? Package { get; set; }
        public Dictionary<string, bool>? Flags { get; set; }
        public bool Local { get; set; }
        public Score? Score { get; set; }
        public float SearchScore { get; set; }
    }
}
