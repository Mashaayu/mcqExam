using MCQExam.Server.Identity;

namespace MCQExam.Server.Services
{
    public interface ITokenService
    {
          Task<string> CreateToken(AppUser User);
    }
}
