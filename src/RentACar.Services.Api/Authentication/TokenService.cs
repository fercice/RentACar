using Microsoft.IdentityModel.Tokens;
using RentACar.Domain.Core.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RentACar.Services.Api.Authentication
{
    public class TokenService
    {
        protected TokenService() { }

        public static string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
