using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace posBackend.EF.Migrations
{
    public partial class CreateStoreAndOpenBalnce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpenBalances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeId = table.Column<int>(type: "int", nullable: false),
                    OpenBalanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpenBalances_Stores_storeId",
                        column: x => x.storeId,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenBalancesDt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenBalanceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Quantity]*[PurchasePrice]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalancesDt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpenBalancesDt_OpenBalances_OpenBalanceId",
                        column: x => x.OpenBalanceId,
                        principalTable: "OpenBalances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenBalancesDt_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenBalancesDt_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalances_storeId",
                table: "OpenBalances",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalancesDt_OpenBalanceId",
                table: "OpenBalancesDt",
                column: "OpenBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalancesDt_ProductId",
                table: "OpenBalancesDt",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalancesDt_UnitId",
                table: "OpenBalancesDt",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenBalancesDt");

            migrationBuilder.DropTable(
                name: "OpenBalances");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
