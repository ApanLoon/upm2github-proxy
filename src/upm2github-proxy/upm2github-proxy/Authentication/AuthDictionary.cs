

namespace upm2github_proxy.Authentication
{
    public interface IAuthDictionary
    {
        public string GetToken(string username);
    }

    public class AuthDictionary : Dictionary<string, string>, IAuthDictionary
    {
        public AuthDictionary() {}

        public string GetToken(string username)
        {
            return this.ContainsKey(username) ? this[username] : "";
        }
    }
}
