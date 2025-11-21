using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatureAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhotosUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://www.gob.mx/cms/uploads/image/file/418763/20-4.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Entrada y sendero al Tepozteco", "https://elgiroscopo.es/wp-content/uploads/2018/11/entrada_yacimiento_tepozteco.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://elsouvenir.com/wp-content/uploads/2018/08/Campamento-cerca-CDMX-Foto-Parque-Nacional-El-Chico-2.jpg");

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Sendero del Tepozteco, Morelos", "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg" });
        }
    }
}
