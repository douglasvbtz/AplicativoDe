using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class terceiramigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Varicoes",
                table: "ItensMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Varicoes",
                table: "ItensMenu",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
