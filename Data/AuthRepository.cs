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
        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            ServiceResponse<string> resp = new ServiceResponse<string>();
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.userName.ToLower().Equals(userName));

            if(user == null)
            {
                resp.success=false;
                resp.message="User not found.";
            }
            else if(!VerifyPasswordHash(password,user.passwordHash,user.passwordSalt))
            {
                resp.success=false;
                resp.message="Invalid password.";
            }
            else
            {
                resp.Data = user.userId.ToString();
                resp.success=true;
                resp.message="Logged in succesfully";
            }

            return resp;
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

        private bool VerifyPasswordHash(string password, byte[] PasswordHash,byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                for(int i=0;i<computedHash.Length;i++)
                {
                    if(computedHash[i] != PasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}