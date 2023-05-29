using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmCentralProto.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstcentral101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetterProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetterProduct", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_BetterProduct_Farmer_FarmerID",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetterProduct_FarmerID",
                table: "BetterProduct",
                column: "FarmerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetterProduct");
        }
    }
}
