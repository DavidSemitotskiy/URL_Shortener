using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Constants;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Infrastructure.Settings;

namespace UrlShortener.Infrastructure.Extensions
{
    public static class ServiceCollectionDatabaseExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            var databaseSettings = configuration.GetSection(ConfigurationSectionNames.DatabaseSettings).Get<DatabaseSettings>()
                ?? throw new NoNullAllowedException(nameof(ConfigurationSectionNames.DatabaseSettings));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(databaseSettings.ConnectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        }
    }
}