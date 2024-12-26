using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    /// <inheritdoc />
    public partial class son : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Saat",
                table: "Randevular",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Saat",
                table: "PersonelTakvim",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PersonelEkleViewModel",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelDurum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelEkleViewModel", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "HizmetSecimViewModel",
                columns: table => new
                {
                    HizmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonelEkleViewModelPersonelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HizmetSecimViewModel", x => x.HizmetId);
                    table.ForeignKey(
                        name: "FK_HizmetSecimViewModel_PersonelEkleViewModel_PersonelEkleViewModelPersonelId",
                        column: x => x.PersonelEkleViewModelPersonelId,
                        principalTable: "PersonelEkleViewModel",
                        principalColumn: "PersonelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HizmetSecimViewModel_PersonelEkleViewModelPersonelId",
                table: "HizmetSecimViewModel",
                column: "PersonelEkleViewModelPersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HizmetSecimViewModel");

            migrationBuilder.DropTable(
                name: "PersonelEkleViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "Saat",
                table: "Randevular",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "Saat",
                table: "PersonelTakvim",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
