using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class AddWeddingFKApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ints",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "WeddingID",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wedding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geolocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedding", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_WeddingID",
                table: "Users",
                column: "WeddingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wedding_WeddingID",
                table: "Users",
                column: "WeddingID",
                principalTable: "Wedding",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wedding_WeddingID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Wedding");

            migrationBuilder.DropIndex(
                name: "IX_Users_WeddingID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WeddingID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Ints",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
