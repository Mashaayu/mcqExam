using E_Commerce.Interfaces.Token_Interface;
using E_Commerce.Models.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Repository.Token_Repo_Implementatio
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName)

            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = configuration["Token:Issuer"],
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
