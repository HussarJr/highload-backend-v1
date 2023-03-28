using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace highload_backend_v1.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    price = table.Column<int>(type: "integer", nullable: true),
                    count = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    customer = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    products = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "cart_customer_fkey",
                        column: x => x.customer,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "cart_products_fkey",
                        column: x => x.products,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    customer = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orders_pkey", x => x.id);
                    table.ForeignKey(
                        name: "orders_customer_fkey",
                        column: x => x.customer,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders_elements",
                columns: table => new
                {
                    order_id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    element_id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "orders_elements_element_id_fkey",
                        column: x => x.element_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_elements_order_id_fkey",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_customer",
                table: "cart",
                column: "customer");

            migrationBuilder.CreateIndex(
                name: "IX_cart_products",
                table: "cart",
                column: "products");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer",
                table: "orders",
                column: "customer");

            migrationBuilder.CreateIndex(
                name: "IX_orders_elements_element_id",
                table: "orders_elements",
                column: "element_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_elements_order_id",
                table: "orders_elements",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "orders_elements");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
