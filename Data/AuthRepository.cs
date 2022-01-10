using AutoMapper;
using Hostitan.API.Data;
using Hostitan.API.DTO.Users;
using Hostitan.API.Models;
using Hostitan.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Hostitan_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext;

        public AuthRepository(IMapper mapper, DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public Task<ServiceResponse<int>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(AddUserDTO user)
        {
            ServiceResponse<int> resp = new ServiceResponse<int>();

            User newUser = _mapper.Map<User>(user);

            if(await UserExists(newUser.userName))
            {
                resp.success = false;
                resp.message = "User Already Exists.";

                return resp;
            }

            CreatePasswordHash(user.password,out byte[] pwdHash,out byte[] pwdSalt);

            newUser.passwordHash = pwdHash;
            newUser.passwordSalt = pwdSalt;

           _dbContext.Users.Add(newUser);
           await _dbContext.SaveChangesAsync(); 


           resp.Data = newUser.userId;
           resp.success = true;
           resp.message = "User saved successfuly"; 

           return resp;
        }

        public async Task<bool> UserExists(string userName)
        {
            if(await _dbContext.Users.AnyAsync(x => x.userName.ToLower().Equals(userName.ToLower())))
                return true;
            else
                return false;
        }

        private void CreatePasswordHash(string password,out byte[] PasswordHash,out byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}