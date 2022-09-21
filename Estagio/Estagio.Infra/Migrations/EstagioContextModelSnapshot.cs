﻿// <auto-generated />
using System;
using Estagio.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estagio.Data.Migrations
{
    [DbContext(typeof(EstagioContext))]
    partial class EstagioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Estagio.Domain.Entities.Compra", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdUsuario")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<long?>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Estagio.Domain.Entities.CompraProduto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<long?>("CompraId")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdCompra")
                        .HasColumnName("IdCompra")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdProduto")
                        .HasColumnName("IdProduto")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Quantidade")
                        .HasColumnName("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CompraProduto");
                });

            modelBuilder.Entity("Estagio.Domain.Entities.Produto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Marca")
                        .HasColumnName("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnName("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnName("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Estagio.Domain.Entities.Usuario", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnName("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnName("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Estagio.Domain.Entities.Compra", b =>
                {
                    b.HasOne("Estagio.Domain.Entities.Usuario", null)
                        .WithMany("Compras")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Estagio.Domain.Entities.CompraProduto", b =>
                {
                    b.HasOne("Estagio.Domain.Entities.Compra", null)
                        .WithMany("CompraProdutos")
                        .HasForeignKey("CompraId");

                    b.HasOne("Estagio.Domain.Entities.Produto", null)
                        .WithMany("CompraProdutos")
                        .HasForeignKey("ProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}
