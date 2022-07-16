using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Migrations
{
    /// <inheritdoc />
    public partial class AddAllToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Associate",
                columns: table => new
                {
                    AssociateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourlyRate = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)",nullable: false),
                    Email=table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associate", x => x.AssociateID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associate");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
