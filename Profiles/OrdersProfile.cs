using AutoMapper;
using Hostitan.API.DTO.Orders;
using Hostitan.API.Models;

namespace Hostitan.API.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Orders,GetOrdersDTO>();
        }
    }
}