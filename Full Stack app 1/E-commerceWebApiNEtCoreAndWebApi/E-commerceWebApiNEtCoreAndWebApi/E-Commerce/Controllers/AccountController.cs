using E_Commerce.Interfaces.Token_Interface;
using E_Commerce.Models.DTOS;
using E_Commerce.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
            _userManager = userManager;
           _signInManager = signInManager;
            this.tokenService = tokenService;
        }
        
        [HttpGet("GetAuthorized")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);

            return new UserDTO { 
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = tokenService.CreateToken(user)
            };

        }

        [HttpPost("login")]

        public async Task<ActionResult<UserDTO>> Login( LoginDTO loginDTO)
        {
            var user =  await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return new UserDTO
            {

                Email = user.Email,
                Token = tokenService.CreateToken(user),
                DisplayName = user.DisplayName,
                UserName = user.UserName,
            };

        }


        [HttpPost("Register")]

        public async Task<ActionResult<UserDTO>> Register(RegistrDTO registerDTO)
        {
            var user = new AppUser
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.UserName,

            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                BadRequest(result.Errors);
            }

            return new UserDTO
            {
                Email = registerDTO.Email,
                Token = tokenService.CreateToken(user),
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.UserName,
            };
        }
    }
}
