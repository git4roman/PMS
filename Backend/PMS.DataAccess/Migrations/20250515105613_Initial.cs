using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    category_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
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
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    product_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    image_url = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "date", nullable: false),
                    updated_date = table.Column<DateTime>(type: "date", nullable: false),
                    updated_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    created_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_OrderItemEntity_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CreatedTime", "CustomerId", "DelieveryAddress", "Description", "Guid", "OrderStatus" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9178)), 101, "123 Maple Street, Springfield", "Grocery order for weekly supplies", new Guid("fb3eb877-677b-43ae-b047-dc70731036d8"), "Pending" },
                    { 2, new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9181)), 102, "456 Oak Avenue, Rivertown", "Electronics purchase", new Guid("49e0eea5-e1ed-4d37-aa9c-77e8fd783f1f"), "Pending" },
                    { 3, new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9183)), 103, "789 Pine Road, Hillview", "Clothing order for summer collection", new Guid("229a5c6b-f928-4a4d-ae51-289901553959"), "Pending" },
                    { 4, new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9188)), 104, "321 Cedar Lane, Lakeside", "Furniture delivery", new Guid("7bef04f2-634f-4627-9600-5dc118bdb03f"), "Pending" },
                    { 5, new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9190)), 105, "654 Birch Street, Sunnyvale", "Cancelled book order", new Guid("3494126d-cd38-4a8a-83b7-17b35d013f1c"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedTime", "Email", "FirstName", "LastName", "MiddleName", "PasswordHash", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Butwal", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9133)), "admin@admin.com", "Ram", "Thapa", "Bahadur", "hashedPassword1", "9800000000", "InActive" },
                    { 2, "Lalitpur", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9135)), "sita@example.com", "Sita", "Maharjan", "", "hashedPassword2", "9800000001", "InActive" },
                    { 3, "Pokhara", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9137)), "kiran@example.com", "Kiran", "Gurung", "Kumar", "hashedPassword3", "9800000002", "InActive" },
                    { 4, "Kathmandu", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9138)), "anil@example.com", "Anil", "Shrestha", "", "hashedPassword4", "9800000003", "InActive" },
                    { 5, "Biratnagar", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9140)), "meena@example.com", "Meena", "Tharu", "Devi", "hashedPassword5", "9800000004", "InActive" },
                    { 6, "Dharan", new DateOnly(2025, 5, 15), new TimeOnly(16, 41, 12, 920).Add(TimeSpan.FromTicks(9142)), "hari@example.com", "Hari", "Rai", "", "hashedPassword6", "9800000005", "InActive" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "description", "guid", "image_url", "category_name" },
                values: new object[,]
                {
                    { 1, "Seeds and plants for agriculture and gardening.", new Guid("e1168fb4-6a6e-4fe8-9b0e-65282fbfb341"), "images/categories/crops.jpg", "Crops" },
                    { 2, "Essential tools for planting, digging, and maintaining your garden.", new Guid("a4f255b0-2315-4dee-b4b8-4dacf86457fe"), "images/categories/tools.jpg", "Tools" },
                    { 3, "Fertilizers, pesticides, and insecticides for healthy plant growth.", new Guid("af7963ee-4124-4e93-b85e-b42b97750ded"), "images/categories/chemicals.jpg", "Chemicals" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "product_id", "category_id", "created_date", "created_time", "description", "guid", "image_url", "product_name", "price", "quantity", "status", "updated_date", "updated_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209057), "High-yield tomato seeds suitable for home and farm use.", new Guid("f97d4794-f93a-4d58-88da-b07e4f3ff1c1"), "images/products/tomato_seeds.jpg", "Tomato Seeds", 0m, 3, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 2, 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209066), "Nutritious leafy vegetable ready for home garden transplant.", new Guid("196b1c7a-f541-4618-a507-4991bfa27a97"), "images/products/spinach_plant.jpg", "Spinach Plant", 0m, 5, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 3, 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209068), "Spicy chili seeds ideal for warm climates.", new Guid("c78f1ebe-9a59-4179-a21d-1d03e4ca3d89"), "images/products/chili_seeds.jpg", "Chili Seeds", 0m, 2, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 4, 2, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209070), "Durable tool for digging and planting small plants.", new Guid("17406890-dcce-4908-bfb7-b887ef1dffd6"), "images/products/hand_trowel.jpg", "Hand Trowel", 0m, 7, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 5, 2, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209084), "Sharp blade tool for trimming plants and bushes.", new Guid("22b2af02-cb91-4a0a-b2ed-8a4a7b45ad2f"), "images/products/pruning_shears.jpg", "Pruning Shears", 0m, 10, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 6, 2, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209087), "Lightweight watering can with long spout for even watering.", new Guid("31d12078-72d1-4788-b4aa-a93d35d0ada9"), "images/products/watering_can.jpg", "Watering Can", 0m, 12, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 7, 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209089), "Organic pesticide for controlling aphids and mealybugs.", new Guid("33f8cd70-6b25-49d7-a085-1ac0d0e759bb"), "images/products/neem_oil.jpg", "Pesticide - Neem Oil", 0m, 8, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 8, 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209091), "Fast-acting insecticide for outdoor crops.", new Guid("44849150-f135-4976-80ba-cb57740c4506"), "images/products/cypermethrin.jpg", "Insecticide - Cypermethrin", 0m, 10, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) },
                    { 9, 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(600729209093), "Balanced fertilizer to promote plant growth.", new Guid("eb747c24-0c46-439b-b73f-7b95c3b213cf"), "images/products/npk_fertilizer.jpg", "Fertilizer - NPK 20:20:20", 0m, 15, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "OrderItemEntity",
                columns: new[] { "Id", "CreatedDate", "CreatedTime", "Description", "Guid", "Name", "OrderId", "ProductId", "Quantity", "ShippingCharge", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Two packets of tomato seeds", new Guid("7b65c3a9-565d-4dd2-8439-9bb656720f8a"), "Tomato Seeds x2", 1, 1, 2, 1.00m, 7.00m, 3.00m },
                    { 2, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Garden hand tool", new Guid("50748637-4057-42c9-938a-eca5a5f1b2ab"), "Hand Trowel", 1, 4, 1, 1.00m, 8.00m, 7.00m },
                    { 3, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Organic pesticide", new Guid("7fdcf96e-af72-42e2-aad2-35b50f0d2e8c"), "Neem Oil Bottle", 2, 7, 1, 1.00m, 9.00m, 8.00m },
                    { 4, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Set of 3 spinach plants", new Guid("7e793437-b381-45dc-ac20-3e9bc8c46903"), "Spinach Plant x3", 3, 2, 3, 1.00m, 16.00m, 5.00m },
                    { 5, new DateOnly(1, 1, 1), new TimeOnly(0, 0, 0), "Sharp pruning shears", new Guid("db343ed9-41e5-4e4c-9aea-0b5e3db6cdec"), "Pruning Shears", 4, 5, 1, 1.00m, 11.00m, 10.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_name",
                table: "categories",
                column: "category_name");

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
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_product_name",
                table: "products",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "IX_products_status",
                table: "products",
                column: "status");
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
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
