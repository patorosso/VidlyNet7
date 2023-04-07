using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyNet7.Migrations
{
    /// <inheritdoc />
    public partial class BirthdateNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Customers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
