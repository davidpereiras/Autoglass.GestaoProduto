﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Repository.Entities.ProdutoEntity", b =>
                {
                    b.Property<int>("CodigoProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CNPJFornecedor")
                        .HasColumnType("text");

                    b.Property<int>("CodigoFornecedor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DescricaoFornecedor")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("SituacaoProduto")
                        .HasColumnType("boolean");

                    b.HasKey("CodigoProduto");

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
