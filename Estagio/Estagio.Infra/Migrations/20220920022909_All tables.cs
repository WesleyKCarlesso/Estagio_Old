using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estagio.Data.Migrations
{
    public partial class Alltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Quantidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<long>(nullable: true),
                    UsuarioId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompraProduto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false),
                    IdCompra = table.Column<long>(nullable: true),
                    IdProduto = table.Column<long>(nullable: true),
                    Quantidade = table.Column<decimal>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    CompraId = table.Column<long>(nullable: true),
                    ProdutoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId",
                table: "Compra",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_CompraId",
                table: "CompraProduto",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_ProdutoId",
                table: "CompraProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProduto");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
