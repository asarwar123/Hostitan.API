using Hostitan.API.DTO.Users;
using Hostitan.API.Services;

namespace Hostitan_API.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(AddUserDTO user);

         Task<ServiceResponse<int>> Login(string userName,string password);

         Task<bool> UserExists(string userName);
    }
}