using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Faculty
    {
        [Key]
        public long FacultyId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string FullName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be 10 digits")]
        public long Contact { get; set; }
        [Required(ErrorMessage = "Faculty Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$",
        ErrorMessage = "Password must be between 8 to 16 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public required string Password { get; set; } = "Faculty@123";

    }
}
