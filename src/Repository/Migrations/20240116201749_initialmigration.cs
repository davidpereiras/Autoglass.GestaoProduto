using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoProduto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SituacaoProduto = table.Column<bool>(type: "boolean", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CodigoFornecedor = table.Column<int>(type: "integer", nullable: false),
                    DescricaoFornecedor = table.Column<string>(type: "text", nullable: true),
                    CNPJFornecedor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.CodigoProduto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
