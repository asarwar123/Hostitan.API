using Hostitan.API.DTO.Customers;

namespace Hostitan.API.DTO.Subscriptions
{
    public class GetSubscriptions
    {
        public Guid order_id { get; private set; }
        ///////public GetOrdersDTO {get; private Stream;}
        public GetCustomersDTO customer{get; private set;}
        public string subs_type{get;set;} //monthly | yearly
        public DateTime next_invoice_date { get; set; }
    }
}