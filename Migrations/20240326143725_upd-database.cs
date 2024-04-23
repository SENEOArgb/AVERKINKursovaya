using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovayaMAIN.Migrations
{
    /// <inheritdoc />
    public partial class upddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    consumableId = table.Column<int>(type: "INTEGER", nullable: false),
                    consumableName = table.Column<string>(type: "TEXT", nullable: false),
                    consumableType = table.Column<string>(type: "TEXT", nullable: true),
                    consumablePrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "INTEGER", nullable: false),
                    orderArticle = table.Column<string>(type: "TEXT", nullable: true),
                    tariffName = table.Column<string>(type: "TEXT", nullable: true),
                    tariffPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    countBalls = table.Column<int>(type: "INTEGER", nullable: false),
                    orderProcessTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    orderProcessDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    userName = table.Column<string>(type: "TEXT", nullable: false),
                    userSurname = table.Column<string>(type: "TEXT", nullable: true),
                    passportSeries = table.Column<int>(type: "INTEGER", nullable: false),
                    passportNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    weaponId = table.Column<int>(type: "INTEGER", nullable: false),
                    weaponName = table.Column<string>(type: "TEXT", nullable: false),
                    weaponCategory = table.Column<string>(type: "TEXT", nullable: false),
                    manufacturerWeapon = table.Column<string>(type: "TEXT", nullable: true),
                    countryManufactureWeapon = table.Column<string>(type: "TEXT", nullable: true),
                    combatCaliber = table.Column<string>(type: "TEXT", nullable: true),
                    yearManufactureWeapon = table.Column<int>(type: "INTEGER", nullable: true),
                    serialNumberWeapon = table.Column<string>(type: "TEXT", nullable: true),
                    weightWeapon = table.Column<double>(type: "REAL", nullable: true),
                    acummulator = table.Column<string>(type: "TEXT", nullable: true),
                    magazineCapacity = table.Column<int>(type: "INTEGER", nullable: true),
                    materialWeapon = table.Column<string>(type: "TEXT", nullable: true),
                    firingRate = table.Column<int>(type: "INTEGER", nullable: true),
                    weaponPrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
