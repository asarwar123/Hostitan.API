using System.ComponentModel.DataAnnotations;

namespace Hostitan.API.Models
{
    public class Invoices
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();

        public Guid subs_id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; }

        [DataType(DataType.Date)]
        public DateTime due_date { get; set; }
        public Status status {get;set;} = Status.active;
    }
}