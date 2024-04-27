using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Prn", "Contact", "Email", "FullName", "Program" },
                values: new object[,]
                {
                    { 8021047427L, 9908765622L, "jankichauhan05@gmail.com", "Janki Chauhan", "SS BE-III" },
                    { 8021050206L, 9786546532L, "maheswaripanda20112004@gmail.com", "Maheswari Panda", "SS BE-III" },
                    { 8021077314L, 9909786590L, "nitixapatel234@gmail.com", "Nitixa Patel", "SS BE-III" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Prn",
                keyValue: 8021047427L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Prn",
                keyValue: 8021050206L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Prn",
                keyValue: 8021077314L);
        }
    }
}
