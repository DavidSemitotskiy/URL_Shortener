using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<User?> FindAsync(string login, string password);
    }
}