using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordColumnToStudentFacultyTableDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "Student@123");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Faculty",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "Faculty@123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Faculty");

        }
    }
}
