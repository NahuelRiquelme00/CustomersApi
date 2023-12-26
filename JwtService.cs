using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomersApi
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string generateToken(string user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user),
            };

            var KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(KEY, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer : _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims, expires : DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"]))
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
