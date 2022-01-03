using AutoMapper;
using Hostitan.API.DTO.Customers;
using Hostitan.API.Models;

namespace Hostitan.API.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IMapper _mapper;
        public CustomerServices(IMapper mapper)
        {
            _mapper = mapper;            
        }
          private static List<Customers> customers = new List<Customers>{
            new Customers("Azeem","Sarwar","RWP","azeem.sawar@gmail.com"),
            new Customers("Nadeem","Sarwar","RWP","nadeem.sawar@gmail.com"),
            new Customers("Naeem","Sarwar","RWP","naeem.sawar@gmail.com")
        };

        public async Task<ServiceResponse<List<GetCustomersDTO>>> GetAllCustomers()
        {
            ServiceResponse<List<GetCustomersDTO>> resp = new ServiceResponse<List<GetCustomersDTO>>();
            //resp.Data = _mapper.Map<GetCustomersDTO>(customers);
           resp.Data = (customers.Select(c => _mapper.Map<GetCustomersDTO>(c))).ToList  ();
            resp.message = "All Customers Data";

            return resp;
        }

        public async Task<ServiceResponse<GetCustomersDTO>> GetCustomerById(Guid id)
        {
            ServiceResponse<GetCustomersDTO> resp = new ServiceResponse<GetCustomersDTO>();
            resp.Data = _mapper.Map<GetCustomersDTO>(customers.FirstOrDefault(c=>c.id == id));
            resp.message = "A single customer data";

            return resp;
        }

        public async Task<ServiceResponse<List<GetCustomersDTO>>> AddCustomer(AddCustomerDTO _newCustomer)
        {
            ServiceResponse<List<GetCustomersDTO>> resp = new ServiceResponse<List<GetCustomersDTO>>();
            
           customers.Add(_mapper.Map<Customers>(_newCustomer));

            resp.Data = customers.Select(c => _mapper.Map<GetCustomersDTO>(c)).ToList();
            resp.message = "New customer Added";

            return resp;
        }
    }
}