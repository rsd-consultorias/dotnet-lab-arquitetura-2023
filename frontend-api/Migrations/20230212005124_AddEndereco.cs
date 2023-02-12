using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class AddEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnderecoCorrespondencia_Logradouro",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPrincipal_Logradouro",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoCorrespondencia_Logradouro",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EnderecoPrincipal_Logradouro",
                table: "Funcionarios");
        }
    }
}
