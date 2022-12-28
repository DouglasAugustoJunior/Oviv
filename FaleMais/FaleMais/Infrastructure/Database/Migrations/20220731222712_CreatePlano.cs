using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaleMais.Migrations
{
    public partial class CreatePlano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinutosGratuitos = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE()"),
                    DataDelecao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });
            migrationBuilder.InsertData(
               table: "Plano",
               columns: new string[] {
                    "Id",
                    "MinutosGratuitos",
                    "Nome"
               },
               values: new string[,] {
                    { "1", "30", "FaleMais 30" },
                    { "2", "60", "FaleMais 60" },
                    { "3", "120", "FaleMais 120" }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plano");
        }
    }
}
