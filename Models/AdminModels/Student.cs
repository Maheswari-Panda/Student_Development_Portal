using System.ComponentModel.DataAnnotations;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Student
    {
        [Key]
        public long Prn { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be 10 digits")]
        public long Contact { get; set; }
        public string Program { get; set; }
        // New property for password
        public required string Password { get; set; } = "Student@123";
    }
}
