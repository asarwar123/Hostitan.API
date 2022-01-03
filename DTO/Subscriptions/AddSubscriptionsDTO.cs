using System.ComponentModel.DataAnnotations;
using Hostitan.API.Models;

namespace Hostitan.API.DTO.Subscriptions
{
    public class AddSubscriptionsDTO
    {
        public Guid order_id { get; set; }
        public Guid customer_id { get; set; }
        public Status Status { get; set; } = Status.active;
        public Hostitan.API.Models.Type type { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; } =  DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime next_invoice_date { get; set; }
    }
}