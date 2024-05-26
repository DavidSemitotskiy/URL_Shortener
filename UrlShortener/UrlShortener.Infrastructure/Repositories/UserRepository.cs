using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<User?> FindAsync(string login, string password)
        {
            return this.entities
                .FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
        }
    }
}