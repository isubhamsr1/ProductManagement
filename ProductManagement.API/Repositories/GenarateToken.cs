using Azure;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagement.API.Repositories
{
    public class GenarateToken : IGenarateToken
    {
        public IConfiguration _config;

        public GenarateToken(IConfiguration config)
        {
            _config = config;
        }
        public Task<string> GetTokenAsync(User user)
        {
			try
			{
                var claims = new List<Claim>();

                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
                claims.Add(new Claim("Id", user.Id.ToString()));
                claims.Add(new Claim("UserName", user.UserName));
                if (user.IsAdmin)
                {
                   claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim("Role", "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Editor"));
                    claims.Add(new Claim("Role", "Editor"));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn);

                return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
