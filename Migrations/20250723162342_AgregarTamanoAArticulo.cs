using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerStock.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTamanoAArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tamano",
                table: "Articulos",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamano",
                table: "Articulos");
        }
    }
}
