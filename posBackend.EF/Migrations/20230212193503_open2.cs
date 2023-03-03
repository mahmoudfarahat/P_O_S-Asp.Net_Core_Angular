using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace posBackend.EF.Migrations
{
    public partial class open2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenBalanceDt");

            migrationBuilder.DropTable(
                name: "OpenBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenBalance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenBalanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpenBalance_Stores_storeId",
                        column: x => x.storeId,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenBalanceDt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenBalanceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalanceDt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpenBalanceDt_OpenBalance_OpenBalanceId",
                        column: x => x.OpenBalanceId,
                        principalTable: "OpenBalance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenBalanceDt_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenBalanceDt_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalance_storeId",
                table: "OpenBalance",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalanceDt_OpenBalanceId",
                table: "OpenBalanceDt",
                column: "OpenBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalanceDt_ProductId",
                table: "OpenBalanceDt",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalanceDt_UnitId",
                table: "OpenBalanceDt",
                column: "UnitId");
        }
    }
}
