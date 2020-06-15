using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rua = table.Column<string>(type: "varchar(80)", nullable: true),
                    Numero = table.Column<string>(type: "char(10)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(80)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: true),
                    EntidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(80)", nullable: true),
                    EntidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EntidadeId",
                table: "Enderecos",
                column: "EntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_EntidadeId",
                table: "Solicitacoes",
                column: "EntidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Entidades");
        }
    }
}
