using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoFolha_Funcionarios_FuncionarioId",
                table: "EventoFolha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoFolha",
                table: "EventoFolha");

            migrationBuilder.DropColumn(
                name: "DataProcessamento",
                table: "EventoFolha");

            migrationBuilder.DropColumn(
                name: "Processado",
                table: "EventoFolha");

            migrationBuilder.DropColumn(
                name: "UltimoProcessamento",
                table: "EventoFolha");

            migrationBuilder.RenameTable(
                name: "EventoFolha",
                newName: "EventosFolha");

            migrationBuilder.RenameIndex(
                name: "IX_EventoFolha_FuncionarioId",
                table: "EventosFolha",
                newName: "IX_EventosFolha_FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosFolha",
                table: "EventosFolha",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosFolha_Funcionarios_FuncionarioId",
                table: "EventosFolha",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosFolha_Funcionarios_FuncionarioId",
                table: "EventosFolha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosFolha",
                table: "EventosFolha");

            migrationBuilder.RenameTable(
                name: "EventosFolha",
                newName: "EventoFolha");

            migrationBuilder.RenameIndex(
                name: "IX_EventosFolha_FuncionarioId",
                table: "EventoFolha",
                newName: "IX_EventoFolha_FuncionarioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProcessamento",
                table: "EventoFolha",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Processado",
                table: "EventoFolha",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoProcessamento",
                table: "EventoFolha",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoFolha",
                table: "EventoFolha",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoFolha_Funcionarios_FuncionarioId",
                table: "EventoFolha",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }
    }
}
