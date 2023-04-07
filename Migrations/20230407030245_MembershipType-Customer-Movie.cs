using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyNet7.Migrations
{
    /// <inheritdoc />
    public partial class MembershipTypeCustomerMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuscribedToNewsLetter",
                table: "Customers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Customers",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsSuscribedToNewsLetter",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customers");
        }
    }
}
