using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Interfaces;
using UrlShortener.Infrastructure.Settings;

namespace UrlShortener.Infrastructure.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly TokenSettings tokenSettings;

        public TokenProvider(IOptions<TokenSettings> tokenSettings)
        {
            this.tokenSettings = tokenSettings.Value
                ?? throw new ArgumentNullException(nameof(tokenSettings));
        }

        public string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.tokenSettings.Key));

            var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: this.tokenSettings.Issuer,
                audience: this.tokenSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(this.tokenSettings.ExpiresIn),
                signingCredentials: creadentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}