using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Data.Migrations
{
    public partial class rentalStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmationStatus",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationStatus",
                table: "Rentals");
        }
    }
}
