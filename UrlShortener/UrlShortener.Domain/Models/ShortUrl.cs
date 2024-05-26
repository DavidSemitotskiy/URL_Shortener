namespace UrlShortener.Domain.Models
{
    public class ShortUrl : BaseEntity<Guid>
    {
        public DateTime CreatedDate { get; set; }

        public string OriginalUrl { get; set; }

        public string ShortenedUrl { get; set; }

        public User? User { get; set; }
    }
}