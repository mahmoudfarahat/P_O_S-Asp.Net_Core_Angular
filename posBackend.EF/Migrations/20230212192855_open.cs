using Microsoft.EntityFrameworkCore.Migrations;

namespace posBackend.EF.Migrations
{
    public partial class open : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalances_Stores_storeId",
                table: "OpenBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalancesDt_OpenBalances_OpenBalanceId",
                table: "OpenBalancesDt");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalancesDt_Products_ProductId",
                table: "OpenBalancesDt");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalancesDt_Units_UnitId",
                table: "OpenBalancesDt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenBalancesDt",
                table: "OpenBalancesDt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenBalances",
                table: "OpenBalances");

            migrationBuilder.RenameTable(
                name: "OpenBalancesDt",
                newName: "OpenBalanceDt");

            migrationBuilder.RenameTable(
                name: "OpenBalances",
                newName: "OpenBalance");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalancesDt_UnitId",
                table: "OpenBalanceDt",
                newName: "IX_OpenBalanceDt_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalancesDt_ProductId",
                table: "OpenBalanceDt",
                newName: "IX_OpenBalanceDt_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalancesDt_OpenBalanceId",
                table: "OpenBalanceDt",
                newName: "IX_OpenBalanceDt_OpenBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalances_storeId",
                table: "OpenBalance",
                newName: "IX_OpenBalance_storeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDt",
                table: "OpenBalanceDt",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[Quantity]*[PurchasePrice]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenBalanceDt",
                table: "OpenBalanceDt",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenBalance",
                table: "OpenBalance",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalance_Stores_storeId",
                table: "OpenBalance",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalanceDt_OpenBalance_OpenBalanceId",
                table: "OpenBalanceDt",
                column: "OpenBalanceId",
                principalTable: "OpenBalance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalanceDt_Products_ProductId",
                table: "OpenBalanceDt",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalanceDt_Units_UnitId",
                table: "OpenBalanceDt",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalance_Stores_storeId",
                table: "OpenBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalanceDt_OpenBalance_OpenBalanceId",
                table: "OpenBalanceDt");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalanceDt_Products_ProductId",
                table: "OpenBalanceDt");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenBalanceDt_Units_UnitId",
                table: "OpenBalanceDt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenBalanceDt",
                table: "OpenBalanceDt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenBalance",
                table: "OpenBalance");

            migrationBuilder.RenameTable(
                name: "OpenBalanceDt",
                newName: "OpenBalancesDt");

            migrationBuilder.RenameTable(
                name: "OpenBalance",
                newName: "OpenBalances");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalanceDt_UnitId",
                table: "OpenBalancesDt",
                newName: "IX_OpenBalancesDt_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalanceDt_ProductId",
                table: "OpenBalancesDt",
                newName: "IX_OpenBalancesDt_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalanceDt_OpenBalanceId",
                table: "OpenBalancesDt",
                newName: "IX_OpenBalancesDt_OpenBalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenBalance_storeId",
                table: "OpenBalances",
                newName: "IX_OpenBalances_storeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDt",
                table: "OpenBalancesDt",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Quantity]*[PurchasePrice]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenBalancesDt",
                table: "OpenBalancesDt",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenBalances",
                table: "OpenBalances",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalances_Stores_storeId",
                table: "OpenBalances",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalancesDt_OpenBalances_OpenBalanceId",
                table: "OpenBalancesDt",
                column: "OpenBalanceId",
                principalTable: "OpenBalances",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalancesDt_Products_ProductId",
                table: "OpenBalancesDt",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenBalancesDt_Units_UnitId",
                table: "OpenBalancesDt",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
