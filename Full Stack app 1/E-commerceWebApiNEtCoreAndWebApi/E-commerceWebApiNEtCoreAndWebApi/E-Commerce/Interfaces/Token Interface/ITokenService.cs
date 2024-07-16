using E_Commerce.Models.Identity;

namespace E_Commerce.Interfaces.Token_Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
