using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hostitan.API.Models
{
    public class Orders
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();

        [ForeignKey("Customers")]
        public Guid customer_id { get; set; }
        public Status status { get; set; } = Status.placed;

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; } = DateTime.Now;  

        public Orders(string _customerID)
        {
            customer_id = Guid.Parse(_customerID);
        }     
        public Orders()
        {
        }   
    }
}