using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent3.Migrations
{
    public partial class inil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clinet",
                columns: table => new
                {
                    ClinetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moblie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinet", x => x.ClinetId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfCars = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__F2D21B76D6F829FC", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyRentPrice = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK__Car__Category__31EC6D26",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardExpirDate = table.Column<DateTime>(type: "date", nullable: false),
                    NameCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK__Payment__ClinetI__48CFD27E",
                        column: x => x.ClinetId,
                        principalTable: "Clinet",
                        principalColumn: "ClinetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    ClinetId = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    DeliverCity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK__Cart__CarId__36B12243",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Cart__ClinetId__37A5467C",
                        column: x => x.ClinetId,
                        principalTable: "Clinet",
                        principalColumn: "ClinetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Cart__DeliverCit__38996AB5",
                        column: x => x.DeliverCity,
                        principalTable: "Location",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    CarUniqeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__D7B37B88824AD2A7", x => x.CarUniqeId);
                    table.ForeignKey(
                        name: "FK__Inventory__CarId__3E52440B",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Inventory__CityI__3F466844",
                        column: x => x.CityId,
                        principalTable: "Location",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Statue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    OrderStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrderFinshDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrderSubmitDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Orders__CartId__4BAC3F29",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Orders__PaymentI__4CA06362",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    FinshDate = table.Column<DateTime>(type: "date", nullable: true),
                    CarUniqeId = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveledInKilo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK__History__CarUniq__4222D4EF",
                        column: x => x.CarUniqeId,
                        principalTable: "Inventory",
                        principalColumn: "CarUniqeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Category",
                table: "Car",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CarId",
                table: "Cart",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClinetId",
                table: "Cart",
                column: "ClinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DeliverCity",
                table: "Cart",
                column: "DeliverCity");

            migrationBuilder.CreateIndex(
                name: "IX_History_CarUniqeId",
                table: "History",
                column: "CarUniqeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CarId",
                table: "Inventory",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CityId",
                table: "Inventory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ClinetId",
                table: "Payment",
                column: "ClinetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Clinet");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
