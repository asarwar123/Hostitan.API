namespace Hostitan.API.DTO.Customers
{
    public class GetCustomersDTO
    {
        public Guid id { get; set; } = Guid.NewGuid();
        
        public string CustomerName {get; set;}

        public string Email { get; set; }

        public string City { get; set; }
        
        public string Status { get; set; }

        public string CustomerSince { get; set; }  // Aug 2021 (4 months ago)
    }
}