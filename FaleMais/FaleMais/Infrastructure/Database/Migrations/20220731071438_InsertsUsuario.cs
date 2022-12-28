using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaleMais.Migrations
{
    public partial class InsertsUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Usuario",
               columns: new string[] {
                    "Nome",
                    "Senha",
                    "Autorizacao"
               },
               values: new string[,] {
                    { "CEO", "12345678","Administrador" },
                    { "Administrador", "12345678","Administrador" },
                    { "Moderador", "12345678","Administrador" },
                    { "Operador", "12345678","Cliente" },
                    { "Cliente", "12345678","Cliente" }
               });
        }
    }
}
