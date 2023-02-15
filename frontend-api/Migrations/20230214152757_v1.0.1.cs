using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolhaFuncionario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Identificacao = table.Column<string>(type: "TEXT", nullable: true),
                    DataProcessamento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PeriodoFolha_Inicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PeriodoFolha_Fim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FuncionarioId = table.Column<string>(type: "CHAR(36)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolhaFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolhaFuncionario_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RubricaFolha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CodigoRubrica = table.Column<string>(type: "TEXT", nullable: true),
                    DescricaoRubrica = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: true),
                    FolhaFuncionarioId = table.Column<string>(type: "CHAR(36)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubricaFolha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RubricaFolha_FolhaFuncionario_FolhaFuncionarioId",
                        column: x => x.FolhaFuncionarioId,
                        principalTable: "FolhaFuncionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FolhaFuncionario_FuncionarioId",
                table: "FolhaFuncionario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RubricaFolha_FolhaFuncionarioId",
                table: "RubricaFolha",
                column: "FolhaFuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RubricaFolha");

            migrationBuilder.DropTable(
                name: "FolhaFuncionario");
        }
    }
}
