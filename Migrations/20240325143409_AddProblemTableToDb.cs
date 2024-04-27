using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Migrations
{
	public partial class AddProblemTableToDb : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Problems",
				columns: table => new
				{
					ProblemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Inputs = table.Column<List<string>>(type: "nvarchar(max)", nullable: true),
					Outputs = table.Column<List<string>>(type: "nvarchar(max)", nullable: true),
					TimeComplexity = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SpaceComplexity = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Hint = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					FacultyId = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Problems", x => x.ProblemId);
					table.ForeignKey(
						name: "FK_Problems_Courses_CourseId",
						column: x => x.CourseId,
						principalTable: "Courses",
						principalColumn: "CourseId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Problems_Faculty_FacultyId",
						column: x => x.FacultyId,
						principalTable: "Faculty",
						principalColumn: "FacultyId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Problems",
				columns: new[] { "ProblemId", "Statement", "Description", "Inputs", "Outputs", "TimeComplexity", "SpaceComplexity", "Level", "Hint", "Solution", "CourseId", "FacultyId" },
				values: new object[,]
				{
					{ "P1", "Example problem statement 1", "Example problem description 1", null, null, "O(n)", "O(1)", "Easy", "Example hint 1", "Example solution 1", "CSE5501", 2024000001L },
					{ "P2", "Example problem statement 2", "Example problem description 2", null, null, "O(log n)", "O(n)", "Medium", "Example hint 2", "Example solution 2", "CSE6502", 2024000001L }
                    // Add more problems if needed
                });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Problems");
		}
	}
}