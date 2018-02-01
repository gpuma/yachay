using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace yachay.Migrations
{
    public partial class wot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Enrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Enrollments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
