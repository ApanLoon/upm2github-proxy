namespace upm2github_proxy.Models;

public class Repository
{
    public string Type { get; set; } = "git"; // TODO: enum?
    public string Url { get; set; } = "";
}