using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class AddEnderecoAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_CEP",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_Cidade",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_CodigoCidadeIBGE",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_Complemento",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_Numero",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_TipoLogradouro",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_UF",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_CEP",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_Cidade",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_CodigoCidadeIBGE",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_Complemento",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_Numero",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_TipoLogradouro",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_UF",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_CEP",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_Cidade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_CodigoCidadeIBGE",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_Complemento",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_Numero",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_TipoLogradouro",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_UF",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_CEP",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_Cidade",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_CodigoCidadeIBGE",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_Complemento",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_Numero",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_TipoLogradouro",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_UF",
                table: "Funcionarios");
        }
    }
}
