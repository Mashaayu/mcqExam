using ExamPrep.sever.Context;
using ExamPrep.sever.Identity;
using ExamPrep.sever.Identity.IdentityDTO;
using ExamPrep.sever.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Drawing.Printing;

namespace ExamPrep.sever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager,ITokenService TokenService )
        {
            this.userManager = userManager;
            tokenService = TokenService;
        }

        [HttpGet("Users")]

        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            List<AppUser> users = await userManager.Users.AsQueryable().ToListAsync();
            if (!userManager.Users.Any())
            {
                return BadRequest();
            }
            return Ok(users);
        }

        //[Authorize(Roles ="Admin")]
        [HttpGet("Admins")]
        public async Task<ActionResult<AppUser>> GetAdmins()
        {
            var Admins = await userManager.GetUsersInRoleAsync("Admin");
            if (!Admins.Any()) {
                return NotFound();
            }
            return Ok(Admins);
        }


      

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            AppUser User = await userManager.FindByNameAsync(loginDTO.UserName);
            if (User == null) {
                return NotFound($"{User.UserName} , Not found");
            }

            return new UserDTO()
            {
                UserName = loginDTO.UserName,
                Password = loginDTO.Password,
                Token = await tokenService.CreateToken(User)
            };
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            AppUser User = new AppUser()
            {
                UserName = registerDTO.UserName,
                Password = registerDTO.Password,
                Email = registerDTO.Email
            };

            await userManager.CreateAsync(User,registerDTO.Password);
            await userManager.AddToRoleAsync(User,registerDTO.Role);

            return new UserDTO()
            {
                UserName = User.UserName,
                Password    = User.Password,
            };
        }
    }
}
