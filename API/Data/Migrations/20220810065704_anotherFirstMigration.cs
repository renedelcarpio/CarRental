using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Data.Migrations
{
    public partial class anotherFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandAndModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seaters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrunkSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Available", "BrandAndModel", "GearBox", "PictureUrl", "Price", "Seaters", "TrunkSize", "Type" },
                values: new object[,]
                {
                    { 1, true, "Suzuki Alto", "Manual Transmission", "https://th.bing.com/th/id/R.0a70c93cc6dcc81661078747bc4a9cc4?rik=lwiiImmqtAwm5w&riu=http%3a%2f%2fwww.autosarena.com%2fwp-content%2fuploads%2f2016%2f05%2fMaruti-Suzuki-Alto-800-Superior-White.png&ehk=aEBUZIxBqD3apL6Fs1lA2XzJodnd4nKa2maaCE01%2bDg%3d&risl=&pid=ImgRaw&r=0&sres=1&sresct=1", 100, "4 seaters", "254 liters", "Small" },
                    { 2, true, "Suzuki Celerio", "Automatic Transmission", "https://th.bing.com/th/id/R.d0586968de8a43eee95a1a41e5966e12?rik=ioti2Vk%2bdocK1Q&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fMaruti%2fCelerio+Car+png.png&ehk=FuAjI5ipREVLyIRS4%2bf9G0ES6WWDuCKrwc8qBjjhjsY%3d&risl=&pid=ImgRaw&r=0", 135, "5 seaters", "254 liters", "Small" },
                    { 3, true, "Hyundai Accent", "Automatic Transmission", "https://th.bing.com/th/id/R.877bd017bab0e235737cb90a0af61ecd?rik=QhUPGYNejHH0oQ&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fhyundai%2fHundai-accent-png_angular-front.png&ehk=Lbq%2btnlPeIidhdzUDKBkRkSTyXl0lXN3JlIsZTzItPo%3d&risl=&pid=ImgRaw&r=0", 170, "5 seaters", "388 liters", "Medium" },
                    { 4, true, "Suzuki Vitara", "Manual Transmission", "https://www.autokpplus.cz/User_Files/photos/60361f1ac420d5be032658d065vitarafront.png", 200, "5 seaters", "375 liters", "Medium" },
                    { 5, true, "Toyota Hilux", "Manual Transmission", "https://i1.wp.com/fairwheels.com/wp-content/uploads/2016/11/Toyota-Hilux-Revo-V-Automatic-3.0-price-and-specification.png?fit=980%2C559&ssl=1", 240, "5 seaters", "1 Ton", "Large" },
                    { 6, true, "Toyota Prado", "Automatic Transmission", "https://th.bing.com/th/id/R.1da109636cf679c449393fabd969aef2?rik=ca5rpoWTp9%2fyIQ&pid=ImgRaw&r=0", 300, "7 seaters", "640 liters", "Large" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin@email.com", true, "Pa$$w0rd", "Admin" },
                    { 2, "bob@email.com", false, "Pa$$w0rd", "Bob" },
                    { 3, "kurt@email.com", false, "Pa$$w0rd", "Kurt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
