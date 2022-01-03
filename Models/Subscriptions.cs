using System.ComponentModel.DataAnnotations;

namespace Hostitan.API.Models
{
    
    
    public class Subscriptions
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public Guid order_id { get; set; }
        public Guid customer_id { get; set; }
        public Status Status { get; set; } = Status.active;
        public Type type { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; } =  DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime next_invoice_date { get; set; }
    }
}