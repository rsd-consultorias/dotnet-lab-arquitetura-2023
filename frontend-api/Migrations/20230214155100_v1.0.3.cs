using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodoFolha_Inicio",
                table: "FolhaFuncionario",
                newName: "PERIODO_INICIO");

            migrationBuilder.RenameColumn(
                name: "PeriodoFolha_Fim",
                table: "FolhaFuncionario",
                newName: "PERIODO_FIM");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PERIODO_INICIO",
                table: "FolhaFuncionario",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PERIODO_FIM",
                table: "FolhaFuncionario",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PERIODO_INICIO",
                table: "FolhaFuncionario",
                newName: "PeriodoFolha_Inicio");

            migrationBuilder.RenameColumn(
                name: "PERIODO_FIM",
                table: "FolhaFuncionario",
                newName: "PeriodoFolha_Fim");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PeriodoFolha_Inicio",
                table: "FolhaFuncionario",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PeriodoFolha_Fim",
                table: "FolhaFuncionario",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);
        }
    }
}
