using Hostitan.API.DTO.Customers;
using Hostitan.API.Models;

namespace Hostitan.API.Services
{
    public interface ICustomerServices
    {
        public Task<ServiceResponse<List<GetCustomersDTO>>> GetAllCustomers();
        public Task<ServiceResponse<GetCustomersDTO>> GetCustomerById(Guid id);
        public Task<ServiceResponse<List<GetCustomersDTO>>> AddCustomer(AddCustomerDTO _newCustomer);

        public GetCustomersDTO GetCustomer(Guid id);
    }
}