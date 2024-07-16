using EmployeeRH.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeRH.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;
        private SymmetricSecurityKey key;
        public TokenService(IConfiguration configuration,
            UserManager<AppUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"]));
        }
        public async Task<string> CreateToken(AppUser user)
        {
            var role = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Role, role.FirstOrDefault())
            };

            var Credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                Issuer = configuration["Token:Issuer"],
                SigningCredentials = Credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
