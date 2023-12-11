using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class setimamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItensMenu_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ItensMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensMenu_PedidoId",
                table: "ItensMenu",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }
    }
}
