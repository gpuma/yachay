using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace yachay.Migrations
{
    public partial class EnrollmentsByUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UnitId",
                table: "Enrollments",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Units_UnitId",
                table: "Enrollments",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Units_UnitId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_UnitId",
                table: "Enrollments");
        }
    }
}
