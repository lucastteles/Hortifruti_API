﻿// <auto-generated />
using System;
using HortifrutiSF.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HortifrutiSF.Repo.Migrations
{
    [DbContext(typeof(ProdutoContext))]
    [Migration("20220701185219_Alteracao")]
    partial class Alteracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PrecoVenda");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.ProdutoEntrada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Fornecedor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Fornecedor");

                    b.Property<float>("Peso")
                        .HasColumnType("real")
                        .HasColumnName("Peso");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preço");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoEntrada");
                });

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeVenda")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeVenda");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.ProdutoEntrada", b =>
                {
                    b.HasOne("HortifrutiSF.Domain.Entidade.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.Venda", b =>
                {
                    b.HasOne("HortifrutiSF.Domain.Entidade.Produto", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("HortifrutiSF.Domain.Entidade.Produto", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
