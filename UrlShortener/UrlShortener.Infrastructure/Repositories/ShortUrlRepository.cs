using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Infrastructure.Repositories
{
    public class ShortUrlRepository : BaseRepository<ShortUrl, Guid>, IShortUrlRepository
    {
        public ShortUrlRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task RemoveAsync(ShortUrl shortUrl)
        {
            this.entities.Remove(shortUrl);
            await this.context.SaveChangesAsync();
        }
    }
}