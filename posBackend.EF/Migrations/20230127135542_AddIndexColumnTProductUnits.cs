﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace posBackend.EF.Migrations
{
    public partial class AddIndexColumnTProductUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "ProductUnits",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "index",
                table: "ProductUnits");
        }
    }
}
