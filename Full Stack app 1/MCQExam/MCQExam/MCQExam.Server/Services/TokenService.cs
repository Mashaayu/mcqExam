using MCQExam.Server.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MCQExam.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(UserManager<AppUser> userManager
            ,IConfiguration Configuration)
        {
            this.userManager = userManager;
            configuration = Configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]));
        }

        public async Task<string> CreateToken(AppUser User)
        {
            var role = await userManager.GetRolesAsync(User);

            var x = User.UserName;
            var y = User.Email;
            var z = role.FirstOrDefault();
                
            var claims = new List<Claim>() {

                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Role,role.FirstOrDefault()),
                new Claim(ClaimTypes.Email,User.Email)
            };

            

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            var TokenDescriptor = new SecurityTokenDescriptor() {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds,
                Issuer = configuration["Token:Issuer"]
                
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(token);
        }
    }
}
