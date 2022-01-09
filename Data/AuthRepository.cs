using Hostitan.API.Models;
using Hostitan.API.Services;

namespace Hostitan_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        public Task<ServiceResponse<int>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> Register(User user, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string userName)
        {
            throw new NotImplementedException();
        }
    }
}