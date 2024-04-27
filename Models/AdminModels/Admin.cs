using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Admin
    {
        [Key]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "AdminId must be of 10 digits")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdminId { get; set; }

        [Required(ErrorMessage = "AdminName is required")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "AdminEmail is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "AdminPassword is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10}$",
            ErrorMessage = "Password must be 10 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string AdminPassword { get; set; }

        [NotMapped]
        public DateTime DateTime { get; set; }

        public Admin()
        {
            DateTime = DateTime.Now; // Set the DateTime property to current date and time when an Admin object is created
        }
    }
}
