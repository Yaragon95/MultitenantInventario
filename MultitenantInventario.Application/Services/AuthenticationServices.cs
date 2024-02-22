using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultitenantInventario.Application.Interfaces;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Application.Services
{
    public class AuthenticationServices(IOptions<JwtConfiguration> jwtConfiguration) : IAuthenticationServices
    {
        private readonly JwtConfiguration _jwtConfiguration = jwtConfiguration.Value;

        public string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Email),
                new("Tenant", user.Organization.Name)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddHours(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
