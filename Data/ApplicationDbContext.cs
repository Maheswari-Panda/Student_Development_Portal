using Microsoft.EntityFrameworkCore;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;
using StudentDevelopmentPortal.Models.FacultyModels;

namespace StudentDevelopmentPortal.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Problem> Problems { get; set; }
		public DbSet<JobReadiness> JobRedinessQ { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<Event>	Events { get; set; }
		public DbSet<Admin> Admins { get; set; }

        // StudentDb
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentProblem> StudentProblems { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }

        //Faculty Db
        public DbSet<FacultyCourse> FacultyCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.Prn, sc.CourseId });

            modelBuilder.Entity<StudentProblem>()
            .HasKey(sc => new { sc.StudentProblemId, sc.Prn, sc.ProblemId });

            modelBuilder.Entity<StudentAssignment>()
            .HasKey(sc => new { sc.StudentAssignmentId, sc.Prn, sc.AssignmentId });

            modelBuilder.Entity<FacultyCourse>()
            .HasKey(sc => new { sc.FacultyId, sc.CourseId });
        }

    }
}
