using EmployeeRH.Identity;
using EmployeeRH.Identity.IdentityDTOs;
using EmployeeRH.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRH.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManger;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;
        private readonly RoleManager<AppRole> roleManager;
        public static int UserId;

        public AccountController(UserManager<AppUser> userManger, SignInManager<AppUser> signInManager
            , ITokenService TokenService,RoleManager<AppRole> roleManager)
        {
            this.userManger = userManger;
            this.signInManager = signInManager;
            tokenService = TokenService;
            this.roleManager = roleManager;
        }

        [HttpGet("GetAdmins")]
        public async Task<ActionResult<List<AppUser>>> GetUserAdminInRole(){

            var admins = await userManger.GetUsersInRoleAsync("admin");
            return admins.ToList();

        }   

        [HttpGet("Get Employees")]
        public async Task<ActionResult<List<AppUser>>> GetUserEmployeeInRole(){

            var employees = await userManger.GetUsersInRoleAsync("employee");
            return employees.ToList();

        }   

        [HttpGet("Get RHs")]
        public async Task<ActionResult<List<AppUser>>> GetUserRHInRole(){

            var rhs = await userManger.GetUsersInRoleAsync("rh");
            return rhs.ToList();

        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDTO>> RegisterUser(RegisterDTO registerDTO)
        {
            AppRole? role = await roleManager.Roles
                            .Where(role => role.Name == registerDTO.Role.ToLower())
                            .FirstOrDefaultAsync();
            if (role == null)
            {
                return BadRequest("Role is Invalid");
            }

            AppUser user = new AppUser()
            {
                Name = registerDTO.Name,
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
            };

            var result = await userManger.CreateAsync(user,registerDTO.Password);
            var roleResult = await userManger.AddToRoleAsync(user,registerDTO.Role);

            if(!result.Succeeded && !roleResult.Succeeded)
            {
                BadRequest("You got an error");
            }

            return new UserDTO()
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                Token = await tokenService.CreateToken(user)
            };
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> LoginUser(LoginDTO loginDTO)
        {
            AppUser user = await userManger.FindByEmailAsync(loginDTO.Email);
            UserId = user.Id;

            if(user == null)
            {
                return NotFound("User Not Found");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user,loginDTO.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Credentials");
            }

            return new UserDTO()
            {
                Username = user.UserName,
                Email = user.Email,
                Token = await tokenService.CreateToken(user)
            };
        }


    }
}
