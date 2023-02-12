using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_Funcionarios_FuncionarioId",
                table: "Documento");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Funcionarios_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documento",
                table: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Endereco",
                type: "CHAR(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoLogradouro",
                table: "Endereco",
                type: "VARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoEndereco",
                table: "Endereco",
                type: "VARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "VARCHAR(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Endereco",
                type: "VARCHAR(240)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Endereco",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Endereco",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "VARCHAR(240)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoCidadeIBGE",
                table: "Endereco",
                type: "CHAR(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Endereco",
                type: "CHAR(240)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Endereco",
                type: "CHAR(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Endereco",
                type: "CHAR(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Endereco",
                type: "VARCHAR(240)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Documento",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Documento",
                type: "CHAR(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AddColumn<short>(
                name: "NumeroVia",
                table: "Documento",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documento",
                table: "Documento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_FuncionarioId",
                table: "Documento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_Funcionarios_FuncionarioId",
                table: "Documento",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Funcionarios_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_Funcionarios_FuncionarioId",
                table: "Documento");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Funcionarios_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documento",
                table: "Documento");

            migrationBuilder.DropIndex(
                name: "IX_Documento_FuncionarioId",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "NumeroVia",
                table: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoLogradouro",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoEndereco",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(240)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Endereco",
                type: "CHAR(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Endereco",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(240)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoCidadeIBGE",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(240)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Endereco",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Documento",
                type: "CHAR(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Documento",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                columns: new[] { "FuncionarioId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documento",
                table: "Documento",
                columns: new[] { "FuncionarioId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_Funcionarios_FuncionarioId",
                table: "Documento",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Funcionarios_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
