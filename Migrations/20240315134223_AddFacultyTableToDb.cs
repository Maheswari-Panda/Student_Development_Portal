using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "FacultyId", "Contact", "Email", "FullName" },
                values: new object[,]
                {
                    { 2024000001L, 9786546532L, "megnadesai0123@gmail.com", "Meghna Desai" },
                    { 2024000002L, 9909786590L, "hetalbhavsar2024@gmail.com", "Hetal Bhavsar" },
                    { 2024000003L, 9908765622L, "khsitijgupte.msu@gmail.com", "Khsitij Gupte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
