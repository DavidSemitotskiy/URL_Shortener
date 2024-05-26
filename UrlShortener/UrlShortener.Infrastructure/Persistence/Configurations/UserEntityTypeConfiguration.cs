using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Domain.Enums;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Persistence.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ArgumentNullException.ThrowIfNull(builder, nameof(builder));

            builder.HasKey(user => user.Id);

            builder
                .Property(user => user.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .Property(user => user.Role)
                .HasConversion(new EnumToStringConverter<Role>());
        }
    }
}