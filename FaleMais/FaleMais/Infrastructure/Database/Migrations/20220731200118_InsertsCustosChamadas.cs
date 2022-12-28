using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaleMais.Migrations
{
    public partial class InsertsCustosChamadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "CustoChamada",
               columns: new string[] {
                    "Id",
                    "OrigemId",
                    "DestinoId",
                    "ValorPorMin"
               },
               values: new string[,] {
                    { "1", "1", "2", "1.9" },
                    { "2", "2", "1", "2.9" },
                    { "3", "1", "3", "1.7" },
                    { "4", "3", "1", "2.7" },
                    { "5", "1", "4", "0.9" },
                    { "6", "4", "1", "1.9" }
               });
        }
    }
}
