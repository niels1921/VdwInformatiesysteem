using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Klant_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Afspraak_Project_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Klant_Project_Id",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Taak_Project_Taak_Id",
                table: "Taak");

            migrationBuilder.DropForeignKey(
                name: "FK_Taak_AspNetUsers_UserId",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_Taak_Id",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_UserId",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Project_Project_Id",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Afspraak_Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Taak_Id",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Afspraak_Id",
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
                name: "Afspraak_Id",
                table: "Afspraak");

            migrationBuilder.AlterColumn<string>(
                name: "User_id",
                table: "Taak",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Taak_User_id",
                table: "Taak",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_AspNetUsers_User_id",
                table: "Taak",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taak_AspNetUsers_User_id",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_User_id",
                table: "Taak");

            migrationBuilder.AlterColumn<int>(
                name: "User_id",
                table: "Taak",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taak_Id",
                table: "Taak",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Taak",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taak_Id",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Klant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Klant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Afspraak_Id",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taak_Taak_Id",
                table: "Taak",
                column: "Taak_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Taak_UserId",
                table: "Taak",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Project_Id",
                table: "Project",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_Afspraak_Id",
                table: "Afspraak",
                column: "Afspraak_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_AspNetUsers_UserId",
                table: "Taak",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
