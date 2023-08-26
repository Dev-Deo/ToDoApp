namespace Shared
{
    public class SD
    {
        public const string Domain = "@ToDo.com";
        private static string _apiBaseUrl = "https://localhost:7262/api";

        public static string FormatUri(string url)
        {
            return string.Format("{0}{1}", _apiBaseUrl, url);
        }

        public static string SessionCurrentUser = "CurrentUser";

    }
}
