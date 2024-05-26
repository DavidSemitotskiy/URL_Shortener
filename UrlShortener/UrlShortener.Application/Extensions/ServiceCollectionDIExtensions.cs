using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Interfaces;
using UrlShortener.Application.Services;

namespace UrlShortener.Application.Extensions
{
    public static class ServiceCollectionDIExtensions
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            services.AddScoped<IShortUrlGenerator, ShortUrlGenerator>();
        }
    }
}