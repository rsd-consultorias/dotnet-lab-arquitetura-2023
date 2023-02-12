using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class _202301211v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    FuncionarioDbModelId = table.Column<string>(type: "VARCHAR(36)", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Emissao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrgaoEmissor = table.Column<string>(type: "TEXT", nullable: true),
                    Validade = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => new { x.FuncionarioDbModelId, x.Id });
                    table.ForeignKey(
                        name: "FK_Documento_Funcionarios_FuncionarioDbModelId",
                        column: x => x.FuncionarioDbModelId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");
        }
    }
}
