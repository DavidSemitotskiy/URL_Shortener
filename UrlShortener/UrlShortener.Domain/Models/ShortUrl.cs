namespace UrlShortener.Domain.Models
{
    public class ShortUrl : BaseEntity<Guid>
    {
        public DateTime CreatedDate { get; set; }

        public string OriginalUrl { get; set; } = default!;

        public string ShortenedUrl { get; set; } = default!;

        public User? User { get; set; }
    }
}