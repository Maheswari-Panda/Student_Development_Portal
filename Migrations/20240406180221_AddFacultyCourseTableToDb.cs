using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyCourseTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacultyCourses",
                columns: table => new
                {
                    FacultyId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyCourses", x => new { x.FacultyId, x.CourseId }); 
                    table.ForeignKey(
                        name: "FK_FacultyCourses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyCourses");
        }
    }
}
