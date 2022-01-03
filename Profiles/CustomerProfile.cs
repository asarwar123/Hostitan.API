using AutoMapper;
using Hostitan.API.DTO.Customers;
using Hostitan.API.Models;

namespace Hostitan.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customers,GetCustomersDTO>()
            .ForMember(dest => 
                    dest.CustomerName,
                    opt => opt.MapFrom(src => string.Concat(src.first_name," " , src.last_name)))
            .ForMember(dest => 
                    dest.CustomerSince,
                    opt => opt.MapFrom(src => string.Concat("Customer Since: ",src.created_at.Year)));

            CreateMap<AddCustomerDTO,Customers>();
        }
    }
}