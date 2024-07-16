using MCQExam.Server.Context;
using MCQExam.Server.Identity;
using MCQExam.Server.Identity.IdentityDTOs;
using MCQExam.Server.Models;
using MCQExam.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCQExam.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService tokenService;
        private readonly RoleManager<AppRole> roleManager;
        private readonly MCQExamDbContext dbContext;
        public static int UserID; // to perform future operations
        public readonly List<string> Roles;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService TokenService,RoleManager<AppRole> roleManager,
            MCQExamDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            tokenService = TokenService;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            Roles = roleManager.Roles.Select(role=>role.Name).ToList();
        }

     
        [HttpGet("Users")]
    

        public async Task<ActionResult<List<AppUser>>> GetUsersAndRoles()
        {
            var data =  _userManager.Users;
            return data.ToList();
        }

        [HttpGet("Roles")]
        public async Task<ActionResult<List<string>>> GetRole()
        {
            return await roleManager.Roles.Select(role => role.Name).ToListAsync();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {

            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            

            if (user == null)
            {
                return NotFound();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            UserID = user.Id;
            return Ok(new UserDTO
            {
                Email = user.Email,
                Token = await tokenService.CreateToken(user),
                UserName = user.UserName,
            });
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new AppUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
                Password = registerDTO.Password,
                PassKey = registerDTO.PassKey,
                Course = registerDTO.Course,
                Level = registerDTO.Level,
                Role = registerDTO.Role
            };

            AppRole? role = await roleManager.Roles
                    .Where(role => role.Name == registerDTO.Role.ToLower())
                    .FirstOrDefaultAsync();
            
            if (role == null || !Roles.Contains(registerDTO.Role.ToLower()))
            {
                return BadRequest("Invalid Role");
            }
            
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            var roleResult = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded && !roleResult.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            //addding data intoDBcontext
            try
            {
                if (user.Role == "instructor")
                {
                    Instructor Instructor = new Instructor()
                    {
                        UserName = registerDTO.UserName,
                        Email = registerDTO.Email,
                        Course = registerDTO.Course,
                    };
                    await dbContext.Instructors.AddAsync(Instructor);

                }
                if (user.Role == "student")
                {
                    Student student = new Student()
                    {
                        UserName = registerDTO.UserName,
                        Email = registerDTO.Email,
                        Course = registerDTO.Course,
                        BaseLevel = registerDTO.Level

                    };
                    await dbContext.Students.AddAsync(student);
                }
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return new UserDTO
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
            };
        }


    }
}
