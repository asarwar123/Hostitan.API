using AutoMapper;
using Hostitan.API.DTO.Users;
using Hostitan.API.Models;

namespace Hostitan.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDTO,User>();
        }
    }
}