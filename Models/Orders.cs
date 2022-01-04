using System.ComponentModel.DataAnnotations;

namespace Hostitan.API.Models
{
    public class Orders
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public Guid customer_id { get; set; }
        public Status status { get; set; } = Status.placed;

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; } = DateTime.Now;  

        public Orders(string _customerID)
        {
            customer_id = Guid.Parse(_customerID);
        }     
    }
}