using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAssignmentTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    StudentAssignmentId = table.Column<int>(type: "int", nullable: false),
                    Prn = table.Column<long>(type: "bigint", nullable: false),
                    AssignmentId = table.Column<long>(type: "bigint", nullable: false),
                    SolutionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedMarks = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.StudentAssignmentId, x.Prn, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Students_Prn",
                        column: x => x.Prn,
                        principalTable: "Students",
                        principalColumn: "Prn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");
        }
    }
}
