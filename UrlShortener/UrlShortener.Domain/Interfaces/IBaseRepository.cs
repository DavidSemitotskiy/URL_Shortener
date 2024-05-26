using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
    }
}