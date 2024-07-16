using EmployeeRH.Identity;

namespace EmployeeRH.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
