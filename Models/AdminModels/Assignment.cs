using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Assignment
    {
        [Key]
        public long AssignmentId { get; set; }
        public required string AssignmentName { get; set; }
        public required string Description { get; set; }
        public required string AssignedDate { get; set; }
        public required string AssignedDueDate { get; set; }
        [Range(0, 100)]
        public int TotalMarks { get; set; }
        [ForeignKey(nameof(CourseId))]
        public string? CourseId { get; set; }
        [ForeignKey(nameof(FacultyId))]
        public required string FacultyId { get; set; }

    }
}
