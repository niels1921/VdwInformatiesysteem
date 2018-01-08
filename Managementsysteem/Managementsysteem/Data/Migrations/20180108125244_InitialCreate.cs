using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_Project_Id",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_Project_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Klant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Klant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_Project_Id",
                table: "Project",
                column: "Project_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Klant_Project_Id",
                table: "Project",
                column: "Project_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
