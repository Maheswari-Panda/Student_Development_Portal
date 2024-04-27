using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentDevelopmentPortal.Models.StudentModels
{
    public class StudentProblem
    {
        [Key]
        public int StudentProblemId { get; set; }
        [Key]
        [ForeignKey(nameof(Prn))]
        public long Prn { get; set; }
        [Key]
        [ForeignKey(nameof(ProblemId))]
        public required string ProblemId { get; set; }
        public required string Solution {  get; set; }
        public required string IsCorrect { get; set; }
    }
}
