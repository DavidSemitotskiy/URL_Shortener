using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Constants;
using UrlShortener.Infrastructure.Interfaces;
using UrlShortener.Infrastructure.Services;
using UrlShortener.Infrastructure.Settings;

namespace UrlShortener.Infrastructure.Extensions
{
    public static class ServiceCollectionDIExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenSettingsSection = configuration.GetSection(ConfigurationSectionNames.TokenSettings);

            services.Configure<TokenSettings>(tokenSettingsSection);
            services.AddScoped<ITokenProvider, TokenProvider>();
        }
    }
}