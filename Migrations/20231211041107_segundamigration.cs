using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicativoDeComida.Migrations
{
    /// <inheritdoc />
    public partial class segundamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Restaurantees_RestauranteId",
                table: "ItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Restaurantees_RestauranteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurantees",
                table: "Restaurantees");

            migrationBuilder.RenameTable(
                name: "Restaurantees",
                newName: "Restaurantes");

            migrationBuilder.RenameColumn(
                name: "OpcoesPersonalizacao",
                table: "ItensMenu",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Restaurantes",
                newName: "senha");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ItemMenuId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ItensMenu",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "ItensMenu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "ItensMenu",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Restaurantes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurantes",
                table: "Restaurantes",
                column: "RestauranteId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Restaurantes_RestauranteId",
                table: "ItensMenu",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "RestauranteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Restaurantes_RestauranteId",
                table: "Pedidos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "RestauranteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Pedidos_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensMenu_Restaurantes_RestauranteId",
                table: "ItensMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Restaurantes_RestauranteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensMenu_PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurantes",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ItemMenuId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ItensMenu");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ItensMenu");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItensMenu");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Restaurantes");

            migrationBuilder.RenameTable(
                name: "Restaurantes",
                newName: "Restaurantees");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "ItensMenu",
                newName: "OpcoesPersonalizacao");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Restaurantees",
                newName: "Localizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurantees",
                table: "Restaurantees",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensMenu_Restaurantees_RestauranteId",
                table: "ItensMenu",
                column: "RestauranteId",
                principalTable: "Restaurantees",
                principalColumn: "RestauranteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Restaurantees_RestauranteId",
                table: "Pedidos",
                column: "RestauranteId",
                principalTable: "Restaurantees",
                principalColumn: "RestauranteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
