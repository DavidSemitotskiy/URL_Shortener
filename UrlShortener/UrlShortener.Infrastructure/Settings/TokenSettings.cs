namespace UrlShortener.Infrastructure.Settings
{
    public class TokenSettings
    {
        public string Key { get; set; } = default!;

        public string Issuer { get; set; } = default!;

        public string Audience { get; set; } = default!;

        public int ExpiresIn { get; set; }
    }
}