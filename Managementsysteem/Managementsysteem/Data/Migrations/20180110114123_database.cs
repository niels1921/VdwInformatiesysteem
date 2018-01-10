using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_KlantId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_KlantId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "Klant_Id",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_Klant_Id",
                table: "Project",
                column: "Klant_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Klant_Klant_Id",
                table: "Project",
                column: "Klant_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_Klant_Id",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_Klant_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Klant_Id",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_KlantId",
                table: "Project",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Klant_KlantId",
                table: "Project",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
