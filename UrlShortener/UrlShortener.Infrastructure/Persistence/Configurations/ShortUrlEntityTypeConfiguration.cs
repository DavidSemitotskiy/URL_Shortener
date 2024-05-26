using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Persistence.Configurations
{
    public class ShortUrlEntityTypeConfiguration : IEntityTypeConfiguration<ShortUrl>
    {
        public void Configure(EntityTypeBuilder<ShortUrl> builder)
        {
            ArgumentNullException.ThrowIfNull(builder, nameof(builder));

            builder
                .HasOne(shortUrl => shortUrl.User)
                .WithMany(user => user.ShortUrls)
                .HasForeignKey(shortUrl => shortUrl.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}