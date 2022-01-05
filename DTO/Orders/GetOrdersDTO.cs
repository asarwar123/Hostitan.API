using Hostitan.API.DTO.Customers;
using Hostitan.API.Models;

namespace Hostitan.API.DTO.Orders
{
    public class GetOrdersDTO
    {
        public Guid id { get; set; }
        //unable to do this 
        //public GetCustomersDTO customer { get; private set; }
        public Guid customer_id { get; set; }
        public Status status { get; set; }
        public DateTime created_at { get; set; } 
    }
}