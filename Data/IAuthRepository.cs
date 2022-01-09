using Hostitan.API.Models;
using Hostitan.API.Services;

namespace Hostitan_API.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User user,string Password);

         Task<ServiceResponse<int>> Login(string userName,string password);

         Task<bool> UserExists(string userName);
    }
}