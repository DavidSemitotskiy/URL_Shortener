namespace UrlShortener.Application.Interfaces
{
    public interface IShortUrlGenerator
    {
        string GenerateShortUrl(string originalUrl);
    }
}