using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Data.Migrations
{
    public partial class rentalReferenceInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationStatus",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "pending");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationStatus",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
