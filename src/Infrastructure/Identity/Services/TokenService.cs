using Farmify_API_v2.src.Core.Entities;
using Farmify_API_v2.src.Infrastructure.Identity.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Farmify_API_v2.src.Infrastructure.Identity.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("status", ((int)user.Status).ToString())
                // Add roles/permissions claims
            };

            var credentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
