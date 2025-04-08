namespace Restaurant.Web.Models.Entities
{
    public class NewProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool Availability { get; set; }
    }
}
