using GitHub_BackEnd.Entities;

namespace GitHub_BackEnd.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
