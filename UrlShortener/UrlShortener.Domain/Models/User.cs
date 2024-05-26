using UrlShortener.Domain.Enums;

namespace UrlShortener.Domain.Models
{
    public class User : BaseEntity<Guid>
    {
        public Role Role { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<ShortUrl>? ShortUrls { get; set; }
    }
}