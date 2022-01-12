using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Hostitan.API.Data;
using Hostitan.API.DTO.Users;
using Hostitan.API.Models;
using Hostitan.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hostitan_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthRepository(IMapper mapper, DatabaseContext dbContext,IConfiguration configuration)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _configuration = configuration;
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
                resp.Data = GenerateToken(user);
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

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.userId.ToString()),
                new Claim(ClaimTypes.Name,user.fullName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Token:Key").Value));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token) ;
        }
    }
}