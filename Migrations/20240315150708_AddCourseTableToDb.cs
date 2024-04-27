using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentDevelopmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPractical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseName", "IsPractical", "MaterialLink", "Program", "TotalMarks" },
                values: new object[,]
                {
                    { "CSE5501", "Computer graphics is about making pictures using computers. It includes 2D and 3D images, animation, interactive graphics, and applications in various fields like entertainment and design. It requires knowledge of computers, programming, and creativity.", "Computer Graphics", "Yes", "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link", "FS BE-III", 150 },
                    { "CSE5503", "Theory of Computation (ToC) is about understanding how computers work and what they can do. It involves studying different kinds of problems and figuring out if they can be solved by computers or not. ", "Theory Of Computation", "No", "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link", "FS BE-III", 150 },
                    { "CSE6502", "Computer networks involve connecting computers together so they can share information. It includes things like understanding how computers communicate, setting up connections between them, and managing the flow of data. People use computer networks for things like accessing the internet, sharing files, and communicating with each other. ", "Computer Networks", "Yes", "https://drive.google.com/drive/folders/1TQXmMKPO8uQoxxfVDmM0RmiSw10gnEvP?usp=drive_link", "FS BE-III", 150 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
