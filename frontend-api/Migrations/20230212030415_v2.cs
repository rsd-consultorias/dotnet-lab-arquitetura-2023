using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Funcionarios",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Endereco",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Endereco",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Documento",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Documento",
                type: "CHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(36)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Funcionarios",
                type: "VARCHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Endereco",
                type: "TEXT",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Endereco",
                type: "VARCHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Documento",
                type: "TEXT",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Documento",
                type: "VARCHAR(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(36)");
        }
    }
}
