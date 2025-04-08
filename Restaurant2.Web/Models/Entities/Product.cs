namespace Restaurant.Web.Models.Entities
{
    public class Product
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool Availability { get; set; }

        //public ICollection<Order> Order { get; set; } = new List<Order>();
    }
}
