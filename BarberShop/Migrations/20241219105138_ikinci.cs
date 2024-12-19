using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    /// <inheritdoc />
    public partial class ikinci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "PersonelTakvim");

            migrationBuilder.AddColumn<bool>(
                name: "Dolu",
                table: "PersonelTakvim",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dolu",
                table: "PersonelTakvim");

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "PersonelTakvim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
