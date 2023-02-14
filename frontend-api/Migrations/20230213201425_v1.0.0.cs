using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Read = table.Column<bool>(type: "INTEGER", nullable: false),
                    Referrer = table.Column<string>(type: "TEXT", nullable: true),
                    ActionType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    Emissao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    OrgaoEmissor = table.Column<string>(type: "VARCHAR(120)", nullable: true),
                    Validade = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    NumeroVia = table.Column<short>(type: "INT(2)", nullable: true),
                    FuncionarioId = table.Column<string>(type: "CHAR(36)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    TipoEndereco = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    TipoLogradouro = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Logradouro = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Complemento = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(240)", nullable: true),
                    CodigoCidadeIBGE = table.Column<string>(type: "CHAR(8)", nullable: true),
                    CEP = table.Column<string>(type: "CHAR(8)", nullable: true),
                    Cidade = table.Column<string>(type: "CHAR(240)", nullable: true),
                    UF = table.Column<string>(type: "CHAR(2)", nullable: true),
                    FuncionarioId = table.Column<string>(type: "CHAR(36)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventoFolha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataProcessamento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UltimoProcessamento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CodigoTransacao = table.Column<string>(type: "CHAR(4)", nullable: true),
                    CodigoEvento = table.Column<string>(type: "CHAR(4)", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<string>(type: "VARCHAR(32)", nullable: true),
                    Historico = table.Column<string>(type: "CHAR(240)", nullable: true),
                    Processado = table.Column<bool>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<string>(type: "CHAR(36)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoFolha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoFolha_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documento_FuncionarioId",
                table: "Documento",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoFolha_FuncionarioId",
                table: "EventoFolha",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CPF",
                table: "Funcionarios",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "EventoFolha");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
