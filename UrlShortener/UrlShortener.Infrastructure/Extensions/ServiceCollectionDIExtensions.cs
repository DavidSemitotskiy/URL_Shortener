using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UrlShortener.Infrastructure.Extensions
{
    public static class ServiceCollectionDIExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            services.AddTokenGeneration(configuration);
            services.AddDatabase(configuration);

            return services;
        }
    }
}