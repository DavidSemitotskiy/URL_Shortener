using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Persistence.Configurations;

namespace UrlShortener.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;

        public DbSet<ShortUrl> ShortUrls { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ShortUrlEntityTypeConfiguration).Assembly);
        }
    }
}