using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces
{
    public interface IShortUrlRepository : IBaseRepository<ShortUrl, Guid>
    {
    }
}