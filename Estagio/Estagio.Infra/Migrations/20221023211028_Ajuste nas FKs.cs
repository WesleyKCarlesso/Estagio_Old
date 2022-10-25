using Microsoft.EntityFrameworkCore.Migrations;

namespace Estagio.Data.Migrations
{
    public partial class AjustenasFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCompra",
                table: "CompraProduto");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "CompraProduto");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Compra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdCompra",
                table: "CompraProduto",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdProduto",
                table: "CompraProduto",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdUsuario",
                table: "Compra",
                type: "bigint",
                nullable: true);
        }
    }
}
