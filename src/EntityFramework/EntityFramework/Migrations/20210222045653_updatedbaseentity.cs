using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.EntityFramework.Migrations
{
    public partial class updatedbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Registrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Registrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Registrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Registrations");
        }
    }
}
