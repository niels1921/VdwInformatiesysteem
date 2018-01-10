using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class @override : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.AddForeignKey(
            name: "FK_Project_Klant_KlantId",
            table: "Project",
            column: "KlantId",
            principalTable: "Klant",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
        }
    }
}
