using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Constants;
using UrlShortener.Infrastructure.Interfaces;
using UrlShortener.Infrastructure.Services;
using UrlShortener.Infrastructure.Settings;

namespace UrlShortener.Infrastructure.Extensions
{
    public static class ServiceCollectionTokenExtension
    {
        public static void AddTokenGeneration(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            var tokenSettingsSection = configuration.GetSection(ConfigurationSectionNames.TokenSettings);

            services.Configure<TokenSettings>(tokenSettingsSection);
            services.AddScoped<ITokenProvider, TokenProvider>();
        }
    }
}