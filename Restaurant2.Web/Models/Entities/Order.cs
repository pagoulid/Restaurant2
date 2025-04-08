using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        //public ICollection<Product> Products { get; set; } = new List<Product>();
        public string CustomerName { get; set; } // 1:N relation with shadow foreign key attempt
        public string Products { get; set; }
        public double TotalPrice  { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; } // 1:N relation with shadow foreign key attempt
    }
}
