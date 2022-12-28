using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaleMais.Migrations
{
    public partial class InsertsDDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "DDD",
               columns: new string[] {
                    "Id",
                    "Nome",
               },
               values: new string[,] {
                    { "1", "011" },
                    { "2", "016" },
                    { "3", "017" },
                    { "4", "018" }
               });
        }
    }
}
