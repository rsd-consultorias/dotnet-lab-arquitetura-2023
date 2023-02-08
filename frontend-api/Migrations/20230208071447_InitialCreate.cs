using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabArquitetura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(36)", nullable: false),
                    CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CPF",
                table: "Funcionarios",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Queues");
        }
    }
}
