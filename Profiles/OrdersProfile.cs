using AutoMapper;
using Hostitan.API.DTO.Orders;
using Hostitan.API.Models;

namespace Hostitan.API.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Orders,GetOrdersDTO>()
            .ForMember(dest =>
                dest.created_at,
                opt => opt.MapFrom(src => src.created_at.ToShortDateString()));
            // .ForMember(dest =>
            //     dest.customer,
            //     opt => opt.MapFrom(src => service.GetCustomer(src.customer_id) ));
        }
    }
}