using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DommyTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DommyTables", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    OrderStatus = table.Column<string>(type: "longtext", nullable: false),
                    DelieveryAddress = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerEntity_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItemEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemEntity_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemEntity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Guid", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Seeds and plants for agriculture and gardening.", new Guid("a584297a-0a3b-4a60-962d-ed8c179d54a2"), "images/categories/crops.jpg", "Crops" },
                    { 2, "Essential tools for planting, digging, and maintaining your garden.", new Guid("f1cdfa86-fdda-4b00-a594-ca9f92686b6c"), "images/categories/tools.jpg", "Tools" },
                    { 3, "Fertilizers, pesticides, and insecticides for healthy plant growth.", new Guid("97c98309-57c7-48c3-b1a2-384d129dc468"), "images/categories/chemicals.jpg", "Chemicals" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CreatedTime", "CustomerId", "DelieveryAddress", "Description", "Guid", "OrderStatus" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9935)), 101, "123 Maple Street, Springfield", "Grocery order for weekly supplies", new Guid("e8285d33-3381-4595-8966-209995bf54a5"), "Pending" },
                    { 2, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9937)), 102, "456 Oak Avenue, Rivertown", "Electronics purchase", new Guid("ff7cf481-0c3e-44ce-b866-2d63590996c1"), "Pending" },
                    { 3, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9939)), 103, "789 Pine Road, Hillview", "Clothing order for summer collection", new Guid("9392d4e7-d233-48fd-8b62-cc2fb6101831"), "Pending" },
                    { 4, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9943)), 104, "321 Cedar Lane, Lakeside", "Furniture delivery", new Guid("dff31598-417f-4290-939f-883adc04f6a4"), "Pending" },
                    { 5, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9975)), 105, "654 Birch Street, Sunnyvale", "Cancelled book order", new Guid("c60d4e68-68a4-435a-b6b4-ac60bd348a07"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedTime", "Email", "FirstName", "LastName", "MiddleName", "PasswordHash", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Butwal", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9901)), "admin@admin.com", "Ram", "Thapa", "Bahadur", "hashedPassword1", "9800000000", "InActive" },
                    { 2, "Lalitpur", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9903)), "sita@example.com", "Sita", "Maharjan", "", "hashedPassword2", "9800000001", "InActive" },
                    { 3, "Pokhara", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9905)), "kiran@example.com", "Kiran", "Gurung", "Kumar", "hashedPassword3", "9800000002", "InActive" },
                    { 4, "Kathmandu", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9906)), "anil@example.com", "Anil", "Shrestha", "", "hashedPassword4", "9800000003", "InActive" },
                    { 5, "Biratnagar", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9907)), "meena@example.com", "Meena", "Tharu", "Devi", "hashedPassword5", "9800000004", "InActive" },
                    { 6, "Dharan", new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9909)), "hari@example.com", "Hari", "Rai", "", "hashedPassword6", "9800000005", "InActive" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "CreatedTime", "Description", "Guid", "ImageUrl", "Name", "Quantity", "Status", "UpdatedDate", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9832)), "High-yield tomato seeds suitable for home and farm use.", new Guid("27a93a37-439c-408c-bb2b-bccf2092688f"), "images/products/tomato_seeds.jpg", "Tomato Seeds", 3, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 2, 1, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9840)), "Nutritious leafy vegetable ready for home garden transplant.", new Guid("9bc80bb1-9d10-450c-8ad7-0201e0b93008"), "images/products/spinach_plant.jpg", "Spinach Plant", 5, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 3, 1, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9841)), "Spicy chili seeds ideal for warm climates.", new Guid("43c5667b-e99f-49a6-a0c5-7c0be92e84b1"), "images/products/chili_seeds.jpg", "Chili Seeds", 2, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 4, 2, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9843)), "Durable tool for digging and planting small plants.", new Guid("ac283f78-0126-4ef6-aa4e-3a1edb379677"), "images/products/hand_trowel.jpg", "Hand Trowel", 7, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 5, 2, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9858)), "Sharp blade tool for trimming plants and bushes.", new Guid("418be461-0180-4358-8554-50d0faf51531"), "images/products/pruning_shears.jpg", "Pruning Shears", 10, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 6, 2, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9860)), "Lightweight watering can with long spout for even watering.", new Guid("d65525fd-afd3-42b6-8b82-bbac4c22a9b9"), "images/products/watering_can.jpg", "Watering Can", 12, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 7, 3, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9862)), "Organic pesticide for controlling aphids and mealybugs.", new Guid("795fdbc0-a971-461d-93dc-af4a7850eca1"), "images/products/neem_oil.jpg", "Pesticide - Neem Oil", 8, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 8, 3, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9864)), "Fast-acting insecticide for outdoor crops.", new Guid("999e3527-4c1c-40ad-bd13-acc18658edfc"), "images/products/cypermethrin.jpg", "Insecticide - Cypermethrin", 10, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) },
                    { 9, 3, new DateOnly(2025, 5, 14), new TimeOnly(8, 43, 42, 78).Add(TimeSpan.FromTicks(9866)), "Balanced fertilizer to promote plant growth.", new Guid("a79c5564-4081-423d-8981-d46520a041ab"), "images/products/npk_fertilizer.jpg", "Fertilizer - NPK 20:20:20", 15, "Active", new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "OrderItemEntity",
                columns: new[] { "Id", "CreatedDate", "CreatedTime", "Description", "Guid", "Name", "OrderId", "ProductId", "Quantity", "ShippingCharge", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Two packets of tomato seeds", new Guid("d1be8d42-c2ad-4382-8513-a9fc0dac8bb6"), "Tomato Seeds x2", 1, 1, 2, 1.00m, 7.00m, 3.00m },
                    { 2, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Garden hand tool", new Guid("cfceb59a-45e2-4540-8f2c-c968df37cfae"), "Hand Trowel", 1, 4, 1, 1.00m, 8.00m, 7.00m },
                    { 3, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Organic pesticide", new Guid("99161013-9575-4ea0-b931-92a31a67181e"), "Neem Oil Bottle", 2, 7, 1, 1.00m, 9.00m, 8.00m },
                    { 4, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Set of 3 spinach plants", new Guid("2b5135b8-0dbc-430a-a88b-7aa0cdc32c29"), "Spinach Plant x3", 3, 2, 3, 1.00m, 16.00m, 5.00m },
                    { 5, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Sharp pruning shears", new Guid("b955b55b-5e81-490b-9b7c-33464afeb79b"), "Pruning Shears", 4, 5, 1, 1.00m, 11.00m, 10.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntity_OrderId",
                table: "CustomerEntity",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntity_UserId",
                table: "CustomerEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemEntity_OrderId",
                table: "OrderItemEntity",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemEntity_ProductId",
                table: "OrderItemEntity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerEntity");

            migrationBuilder.DropTable(
                name: "DommyTables");

            migrationBuilder.DropTable(
                name: "OrderItemEntity");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
