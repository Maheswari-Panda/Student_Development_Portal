using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Problem
    {
        [Key]
        public required string ProblemId { get; set; }
        public required string Statement { get; set; }
        public required string Description { get; set; }
        public List<string>? Inputs { get; set; }
        public List<string>? Outputs { get; set; }
        public string? TimeComplexity { get; set; }
        public string? SpaceComplexity { get; set; }
        public required string Level { get; set; }
        public string? Hint { get; set; }
        public string? Solution { get; set; }
        [ForeignKey(nameof(CourseId))]
        public required string CourseId { get; set; }
        [ForeignKey(nameof(FacultyId))]
        public required long FacultyId { get; set; }


    }

}
