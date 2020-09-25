using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileShop.Online.Migrations
{
    public partial class added2columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateOn",
                table: "Mobiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateOn",
                table: "Mobiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOn",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "UpdateOn",
                table: "Mobiles");
        }
    }
}
