using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class fuck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Klant_Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Project_Project_Id",
                table: "Afspraak");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Project_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Omschrijving",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Afspraak");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Afspraak",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Afspraak");

            migrationBuilder.AddColumn<int>(
                name: "Klant_Id",
                table: "Afspraak",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Omschrijving",
                table: "Afspraak",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Afspraak",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Klant_Id",
                table: "Afspraak",
                column: "Klant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Project_Id",
                table: "Afspraak",
                column: "Project_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Klant_Klant_Id",
                table: "Afspraak",
                column: "Klant_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Project_Project_Id",
                table: "Afspraak",
                column: "Project_Id",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
