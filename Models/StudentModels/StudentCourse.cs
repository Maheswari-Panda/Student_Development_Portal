using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.StudentModels
{
    public class StudentCourse
    {
        [Key]
        [ForeignKey(nameof(Prn))]
        public long Prn { get; set; }
        [Key]
        [ForeignKey(nameof(CourseId))]
        public required string CourseId { get; set; }
    }
}
