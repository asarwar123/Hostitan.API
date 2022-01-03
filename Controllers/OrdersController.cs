using Microsoft.AspNetCore.Mvc;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrdersByOrderID(Guid id)
        {
            return Ok();
        }
    }
}