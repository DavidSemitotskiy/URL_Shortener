using System.Security.Cryptography;
using System.Text;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.Application.Services
{
    public class ShortUrlGenerator : IShortUrlGenerator
    {
        public string GenerateShortUrl(string originalUrl)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(originalUrl));

            string hex = BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
            string shortHex = hex.Substring(0, 15);

            byte[] shortBytes = Enumerable
                .Range(0, shortHex.Length - (shortHex.Length % 2))
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(shortHex.Substring(x, 2), 16))
                .ToArray();

            string base64 = Convert.ToBase64String(shortBytes);

            return base64;
        }
    }
}