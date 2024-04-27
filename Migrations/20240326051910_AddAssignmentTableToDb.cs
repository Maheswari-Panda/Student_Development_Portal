using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignmentTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignedDate", "AssignedDueDate", "AssignmentName", "CourseId", "Description", "FacultyId", "TotalMarks" },
                values: new object[,]
                {
                    { 1L, "26-03-2024", "02-04-2024", "DBMS Assignment 1", "CSE5501", "Design a relational database schema for an online bookstore.", "2024000001", 10 },
                    { 2L, "26-03-2024", "20-04-2024", "DSA Assignment 1", "CSE6502", "Implement a binary search tree and perform various operations like insertion, deletion, and traversal.", "2024000002", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");
        }
    }
}
