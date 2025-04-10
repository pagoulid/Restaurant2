using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Hosting;

namespace Restaurant.Web.Models.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Ensures auto-increment
        public int Id { get; set; }

        [Required]
        [StringLength(30,MinimumLength = 3, ErrorMessage = "Length should be  between 3 and 30.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name can contain only letters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3 , ErrorMessage = "Length should be  between 3 and 30.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Surname can contain only letters.")]
        public string Surname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please provide correct format")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please provide correct format")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
