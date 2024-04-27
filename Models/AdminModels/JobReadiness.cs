using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class JobReadiness
    {
        [Key]
        public required string QuestionId { get; set; }
        [Required]
        public required string Type { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        [ForeignKey(nameof(FacultyId))]
        public long FacultyId { get; set; }
    }
}
