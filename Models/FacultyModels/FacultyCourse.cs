using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentDevelopmentPortal.Models.FacultyModels
{
    public class FacultyCourse
    {

        [Key]
        [ForeignKey(nameof(FacultyId))]
        public long FacultyId { get; set; }
        [Key]
        [ForeignKey(nameof(CourseId))]
        public required string CourseId { get; set; }
    }
}
