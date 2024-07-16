using ExamPrep.sever.Identity;

namespace ExamPrep.sever.Service
{
    public interface ITokenService
    {
       public Task<string>  CreateToken(AppUser user);
    }
}
