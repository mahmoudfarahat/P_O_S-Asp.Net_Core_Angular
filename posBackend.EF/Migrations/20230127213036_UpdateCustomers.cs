using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace posBackend.EF.Migrations
{
    public partial class UpdateCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegisterNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsMixed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
