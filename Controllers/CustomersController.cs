using Microsoft.AspNetCore.Mvc;
using Hostitan.API.DTO.Customers;
using Hostitan.API.Services;
using System.Collections.Generic;
using System.Linq;
using Hostitan.API.DTO.Orders;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices customerServices;
        private readonly IOrderServices orderServices;


        public CustomersController(ICustomerServices _CustomerService, IOrderServices _orderServices)
        {
            customerServices = _CustomerService;
            orderServices = _orderServices;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCustomersDTO>>> GetCustomers(){
            return Ok(await customerServices.GetAllCustomers());
        }        

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCustomersDTO>>> GetCustomer(Guid id)
        {
            return Ok(await customerServices.GetCustomerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCustomersDTO>>> AddCustomer(AddCustomerDTO _newCustomer)
        {
            return Ok(await customerServices.AddCustomer(_newCustomer));
        }

        /////////////////////////Orders Details

        [HttpGet("{id}/orders")]
        public async Task<ActionResult<ServiceResponse<List<GetOrdersDTO>>>> GetOrdersByCustomerID(Guid id)
        {
            return Ok(await orderServices.GetCustomerOrders(id));
        }

        [HttpGet("{customerId}/orders/{orderId}")]
        public async Task<ActionResult<ServiceResponse<List<GetOrdersDTO>>>> GetOrdersByOrderID(Guid customerId,Guid orderId)
        {
            return Ok(await orderServices.GetCustomerOrdersByOrderId(customerId,orderId));
        }
    }
}