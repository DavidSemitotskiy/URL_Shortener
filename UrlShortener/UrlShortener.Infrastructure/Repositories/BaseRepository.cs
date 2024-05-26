using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<TEntity> entities;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.entities = this.context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await this.entities.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.entities.ToListAsync();
        }
    }
}