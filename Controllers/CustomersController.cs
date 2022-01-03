using Microsoft.AspNetCore.Mvc;
using Hostitan.API.DTO.Customers;
using Hostitan.API.Services;
using System.Collections.Generic;
using System.Linq;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        public ICustomerServices customerServices;

        public CustomersController(ICustomerServices _CustomerService)
        {
            customerServices = _CustomerService;
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

        [HttpGet]
        [Route("/{id}/orders")]
        public IActionResult GetOrders(Guid customer_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/{id}/orders/{id}")]
        public IActionResult OrdersByCustomerID(Guid customerId,Guid orderID)
        {
                return Ok();
        }
    }
}