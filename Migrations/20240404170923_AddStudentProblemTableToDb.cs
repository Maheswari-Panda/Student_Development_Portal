using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentProblemTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentProblems",
                columns: table => new
                {
                    StudentProblemId = table.Column<int>(type: "int", nullable: false),
                    Prn = table.Column<long>(type: "bigint", nullable: false),
                    ProblemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProblems", x => new { x.StudentProblemId, x.Prn, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_StudentProblems_Students_Prn",
                        column: x => x.Prn,
                        principalTable: "Students",
                        principalColumn: "Prn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProblems_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentProblems");

        }
    }
}
