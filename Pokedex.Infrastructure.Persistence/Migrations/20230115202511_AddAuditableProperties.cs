using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infrastructure.Persistence.Migrations
{
    public partial class AddAuditableProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tipo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tipo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Tipo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Tipo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Region",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Region",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Region",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Region",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Pokemones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pokemones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Pokemones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Pokemones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tipo");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tipo");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Tipo");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tipo");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Pokemones");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Pokemones");
        }
    }
}
