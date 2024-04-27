using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.StudentModels
{
    public class StudentAssignment
    {
        [Key]
        public int StudentAssignmentId { get; set; }
        [Key]
        [ForeignKey(nameof(Prn))]
        public long Prn {  get; set; }
        [Key]
        [ForeignKey(nameof(AssignmentId))]
        public long AssignmentId { get; set; }
        public string? SolutionUrl {  get; set; }
        public int? AssignedMarks {  get; set; }
        public string? Feedback { get; set; }

    }
}
