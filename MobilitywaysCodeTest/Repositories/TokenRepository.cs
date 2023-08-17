using Microsoft.IdentityModel.Tokens;
using MobilitywaysCodeTest.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobilitywaysCodeTest.Repositories
{
    public class TokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string GenerateJwtToken(User user)
        {
            //Encode the key from the appsettings
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Key"));

            var tokenHandler = new JwtSecurityTokenHandler();
            

            //Create token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.EmailAddress)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
