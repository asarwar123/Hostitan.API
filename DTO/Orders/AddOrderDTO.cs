using Hostitan.API.Models;

namespace Hostitan.API.DTO.Orders
{
    public class AddOrderDTO
    {
        public Guid customer_id { get; set; }
        public Status status { get; set; }
    }
}