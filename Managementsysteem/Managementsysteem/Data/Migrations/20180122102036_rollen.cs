using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class rollen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           
            

            

            migrationBuilder.CreateTable(
                name: "Rollen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rollen_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rollen_User_id",
                table: "Rollen",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rollen");

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
