namespace Restaurant.Web.Models.Entities
{
    public class NewOrderViewModel
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } 
        
        public string Products { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; } // 1:N relation with shadow foreign key attempt
    }
}
