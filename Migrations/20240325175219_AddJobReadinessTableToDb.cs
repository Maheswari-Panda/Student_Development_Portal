using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddJobReadinessTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobRedinessQ",
                columns: table => new
                {
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRedinessQ", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_JobReadinessQ_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId");
                });

            migrationBuilder.InsertData(
                table: "JobRedinessQ",
                columns: new[] { "QuestionId", "Answer", "FacultyId", "Question", "Type" },
                values: new object[,]
                {
                    { "Q1", "Example answer 1", 2024000001L, "Example question 1", "Type1" },
                    { "Q2", "Example answer 2", 2024000002L, "Example question 2", "Type2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobRedinessQ");
        }
    }
}
