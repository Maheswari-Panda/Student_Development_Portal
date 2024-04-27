using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentCourseTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "StudentCourses",
        columns: table => new
        {
            Prn = table.Column<long>(nullable: false),
            CourseId = table.Column<string>(nullable: false, type: "nvarchar(450)")
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_StudentCourses", x => new { x.Prn, x.CourseId });
            table.ForeignKey(
                name: "FK_StudentCourses_Students_Prn",
                column: x => x.Prn,
                principalTable: "Students",
                principalColumn: "Prn",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                column: x => x.CourseId,
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "StudentCourses");
        }
    }
}
