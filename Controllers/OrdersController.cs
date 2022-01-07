using Hostitan.API.DTO.Orders;
using Hostitan.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetOrdersDTO>>>> GetOrdersByCustomerID(Guid id)
        {
            return Ok(_orderServices.GetCustomerOrders(id));
        }
    }
}