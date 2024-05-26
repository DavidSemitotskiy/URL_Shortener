namespace UrlShortener.Domain.Models
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}