using AutoMapper;
using Hostitan.API.Data;
using Hostitan.API.DTO.Customers;
using Hostitan.API.DTO.Orders;
using Hostitan.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostitan.API.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext;

        public CustomerServices(IMapper mapper,DatabaseContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        private static List<Customers> customers = new List<Customers>{
            new Customers("ba071a72-d963-4739-aae4-5a50088528b9","Azeem","Sarwar","RWP","azeem.sawar@gmail.com"),
            new Customers("5886d980-a20f-408b-8c18-27e1087df2f5","Nadeem","Sarwar","RWP","nadeem.sawar@gmail.com"),
            new Customers("1de1130f-9db9-470e-a3e2-16b8fb841c3b","Naeem","Sarwar","RWP","naeem.sawar@gmail.com")
        };

        public async Task<ServiceResponse<List<GetCustomersDTO>>> GetAllCustomers()
        {
            ServiceResponse<List<GetCustomersDTO>> resp = new ServiceResponse<List<GetCustomersDTO>>();
            var dbCustomers = await _dbContext.Customers.ToListAsync();
            //resp.Data = _mapper.Map<GetCustomersDTO>(customers);
           resp.Data = (dbCustomers.Select(c => _mapper.Map<GetCustomersDTO>(c))).ToList();
            resp.message = "All Customers Data";

            return resp;
        }

        public async Task<ServiceResponse<GetCustomersDTO>> GetCustomerById(Guid id)
        {
            ServiceResponse<GetCustomersDTO> resp = new ServiceResponse<GetCustomersDTO>();
            var dbCustomers = await _dbContext.Customers.FirstOrDefaultAsync(c=>c.id ==id);
            resp.Data = _mapper.Map<GetCustomersDTO>(dbCustomers);
            resp.message = "A single customer data";

            return resp;
        }

        public async Task<ServiceResponse<List<GetCustomersDTO>>> AddCustomer(AddCustomerDTO _newCustomer)
        {
            ServiceResponse<List<GetCustomersDTO>> resp = new ServiceResponse<List<GetCustomersDTO>>();
            
           _dbContext.Customers.Add(_mapper.Map<Customers>(_newCustomer));
           await _dbContext.SaveChangesAsync();

            resp.Data = await _dbContext.Customers.Select(c => _mapper.Map<GetCustomersDTO>(c)).ToListAsync();
            resp.message = "New customer Added";

            return resp;
        }

        public GetCustomersDTO GetCustomer(Guid id)
        {
            GetCustomersDTO customerDetails;
            customerDetails = _mapper.Map<GetCustomersDTO>(customers.FirstOrDefault(c=>c.id == id));

            return customerDetails;
        }
    }
}