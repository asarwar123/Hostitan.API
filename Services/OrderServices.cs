using Hostitan.API.DTO.Orders;
using Hostitan.API.Models;
using AutoMapper;

namespace Hostitan.API.Services;

public class OrderServices : IOrderServices
{
    private readonly IMapper _mapper;
    public OrderServices(IMapper mapper)
    {
        _mapper = mapper;
    }
    private static List<Orders> orders = new List<Orders>{
        new Orders("ba071a72-d963-4739-aae4-5a50088528b9"),
        new Orders("5886d980-a20f-408b-8c18-27e1087df2f5"),
        new Orders("1de1130f-9db9-470e-a3e2-16b8fb841c3b")
    };
    public async Task<ServiceResponse<GetOrdersDTO>> GetCustomerOrders(Guid customerId)
    {
        ServiceResponse<GetOrdersDTO> resp = new ServiceResponse<GetOrdersDTO>();

        resp.Data = _mapper.Map<GetOrdersDTO>(orders.First(order => order.customer_id == customerId));
        resp.message = "Orders of a Customer";
        resp.success = true;

        return resp;
    }
    public async Task<ServiceResponse<GetOrdersDTO>> GetCustomerOrdersByOrderId(Guid customerId,Guid orderId)
    {
        ServiceResponse<GetOrdersDTO> resp = new ServiceResponse<GetOrdersDTO>();

        ///// Om Actual this call will be resumed
        //resp.Data = _mapper.Map<GetOrdersDTO>(orders.First(order => order.id == orderId && order.customer_id == customerId ));
        resp.Data = _mapper.Map<GetOrdersDTO>(orders.First(order => order.customer_id == customerId));


        resp.message = "Order of a Customer";
        resp.success = true;

        return resp;
    }
}