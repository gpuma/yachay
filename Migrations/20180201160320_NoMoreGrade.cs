using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace yachay.Migrations
{
    public partial class NoMoreGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.AddColumn<float>(
                name: "Grade1",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Grade2",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Grade3",
                table: "Enrollments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade1",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Grade2",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Grade3",
                table: "Enrollments");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade1 = table.Column<float>(nullable: true),
                    Grade2 = table.Column<float>(nullable: true),
                    Grade3 = table.Column<float>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }
    }
}
