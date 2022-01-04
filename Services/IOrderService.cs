using Hostitan.API.DTO.Orders;

namespace Hostitan.API.Services;

public interface IOrderServices
{
        public Task<ServiceResponse<GetOrdersDTO>> GetCustomerOrders(Guid Id);

        public Task<ServiceResponse<GetOrdersDTO>> GetCustomerOrdersByOrderId(Guid customerId,Guid orderId);

}