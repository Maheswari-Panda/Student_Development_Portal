using System.ComponentModel.DataAnnotations;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string MaterialLink { get; set; }
        public string IsPractical { get; set; }
        [Range(0, 150)]
        public int TotalMarks { get; set; }
        public string Program { get; set; }
    }
}
