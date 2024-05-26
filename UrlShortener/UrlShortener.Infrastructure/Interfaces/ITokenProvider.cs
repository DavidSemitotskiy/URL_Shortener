using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Interfaces
{
    public interface ITokenProvider
    {
        string GetToken(User user);
    }
}