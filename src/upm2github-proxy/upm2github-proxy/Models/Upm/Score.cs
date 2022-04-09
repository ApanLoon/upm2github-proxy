namespace upm2github_proxy.Models.Upm;

public class Score
{
    public float Final { get; set; }
    public ScoreDetail? Detail { get; set; }
}

public class ScoreDetail
{
    public float Quality { get; set; }
    public float Popularity { get; set; }
    public float Maintenance { get; set; }
}
