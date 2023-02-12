using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class AddEnderecoAtributosRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "EnderecoCorrespondencia_Logradouro",
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

            migrationBuilder.CreateTable(
                name: "Funcionarios_EnderecoCorrespondencia",
                columns: table => new
                {
                    FuncionarioDbModelId = table.Column<string>(type: "VARCHAR(36)", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoLogradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoCidadeIBGE = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    UF = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios_EnderecoCorrespondencia", x => new { x.FuncionarioDbModelId, x.Id });
                    table.ForeignKey(
                        name: "FK_Funcionarios_EnderecoCorrespondencia_Funcionarios_FuncionarioDbModelId",
                        column: x => x.FuncionarioDbModelId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios_EnderecoCorrespondencia");

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
                name: "EnderecoCorrespondencia_Logradouro",
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
        }
    }
}
