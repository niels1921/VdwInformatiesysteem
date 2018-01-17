using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Managementsysteem.Data.Migrations
{
    public partial class afspraakupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Afspraak");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Afspraak",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Afspraak",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Afspraak",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Afspraak");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Afspraak",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
