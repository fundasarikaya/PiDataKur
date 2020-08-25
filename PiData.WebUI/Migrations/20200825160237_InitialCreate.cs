using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiData.WebUI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(nullable: true),
                    ForexBuying = table.Column<decimal>(nullable: true),
                    ForexSelling = table.Column<decimal>(nullable: true),
                    BanknoteBuying = table.Column<decimal>(nullable: true),
                    BanknoteSelling = table.Column<decimal>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyInfo");

            migrationBuilder.DropTable(
                name: "CurrencyList");
        }
    }
}
