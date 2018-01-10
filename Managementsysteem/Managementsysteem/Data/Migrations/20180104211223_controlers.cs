using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class controlers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Klant_KlantId",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Project_ProjectId",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_KlantId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_KlantId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_KlantId",
                table: "Afspraak");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_ProjectId",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Afspraak");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Taak",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taak_Id",
                table: "Taak",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Klant_Id",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taak_Id",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Klant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Klant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Afspraak",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Klant_Id",
                table: "Afspraak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Afspraak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taak_Taak_Id",
                table: "Taak",
                column: "Taak_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Klant_Id",
                table: "Project",
                column: "Klant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Project_Id",
                table: "Project",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Afspraak_Id",
                table: "Afspraak",
                column: "Afspraak_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Klant_Id",
                table: "Afspraak",
                column: "Klant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Project_Id",
                table: "Afspraak",
                column: "Project_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Klant_Afspraak_Id",
                table: "Afspraak",
                column: "Afspraak_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Project_Afspraak_Id",
                table: "Afspraak",
                column: "Afspraak_Id",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Klant_Klant_Id",
                table: "Project",
                column: "Klant_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Klant_Project_Id",
                table: "Project",
                column: "Project_Id",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_Project_Taak_Id",
                table: "Taak",
                column: "Taak_Id",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Klant_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Project_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Klant_Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Project_Project_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_Klant_Id",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_Project_Id",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Taak_Project_Taak_Id",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_Taak_Id",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Project_Klant_Id",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_Project_Id",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Project_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Taak_Id",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Afspraak_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Klant_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Taak_Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Afspraak_Id",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Klant");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Klant_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Afspraak");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_KlantId",
                table: "Project",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_KlantId",
                table: "Afspraak",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_ProjectId",
                table: "Afspraak",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Klant_KlantId",
                table: "Afspraak",
                column: "KlantId",
                principalTable: "Klant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraak_Project_ProjectId",
                table: "Afspraak",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
