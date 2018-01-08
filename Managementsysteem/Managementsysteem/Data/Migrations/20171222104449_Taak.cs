using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class Taak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taak_Project_ProjectId",
                table: "Taak");

            migrationBuilder.DropForeignKey(
                name: "FK_Taak_AspNetUsers_WerknemerId",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_ProjectId",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_WerknemerId",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "WerknemerId",
                table: "Taak");

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Taak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Taak",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Taak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taak_Project_Id",
                table: "Taak",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Taak_UserId",
                table: "Taak",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_Project_Project_Id",
                table: "Taak",
                column: "Project_Id",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_AspNetUsers_UserId",
                table: "Taak",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taak_Project_Project_Id",
                table: "Taak");

            migrationBuilder.DropForeignKey(
                name: "FK_Taak_AspNetUsers_UserId",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_Project_Id",
                table: "Taak");

            migrationBuilder.DropIndex(
                name: "IX_Taak_UserId",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Taak");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Taak",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WerknemerId",
                table: "Taak",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taak_ProjectId",
                table: "Taak",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Taak_WerknemerId",
                table: "Taak",
                column: "WerknemerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_Project_ProjectId",
                table: "Taak",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taak_AspNetUsers_WerknemerId",
                table: "Taak",
                column: "WerknemerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
