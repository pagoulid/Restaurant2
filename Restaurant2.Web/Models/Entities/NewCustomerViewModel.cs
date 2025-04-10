using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models.Entities
{
    public class NewCustomerViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Ensures auto-increment
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3 , ErrorMessage = "Length should be  between 3 and 30.")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Length should be  between 3 and 30.")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Non-valid mail.Please provide correct format")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
