using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatureAPI.Migrations
{
    public partial class UpdateSeedPhotosData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 1, "https://www.gob.mx/cms/uploads/image/file/418763/20-4.jpg", "Parque Nacional El Chico en Hidalgo" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 2, "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg", "Cascada de Basaseachic en temporada de lluvias" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 3, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg", "Mirador Peña del Cuervo en la Sierra de Órganos" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 4, "https://elgiroscopo.es/wp-content/uploads/2018/11/entrada_yacimiento_tepozteco.jpg", "Entrada y sendero al Tepozteco" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 5, "https://www.gob.mx/cms/uploads/article/main_image/28051/blog_PNCM.jpg", "Parque Nacional Cumbres de Monterrey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 1, "https://elsouvenir.com/wp-content/uploads/2018/08/Campamento-cerca-CDMX-Foto-Parque-Nacional-El-Chico-2.jpg", "Parque Nacional El Chico en Hidalgo" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 2, "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg", "Cascada de Basaseachic en temporada de lluvias" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 3, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg", "Mirador Peña del Cuervo en la Sierra de Órganos" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 4, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg", "Sendero del Tepozteco, Morelos" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PlaceId", "Url", "Description" },
                values: new object[] { 5, "https://www.gob.mx/cms/uploads/article/main_image/28051/blog_PNCM.jpg", "Parque Nacional Cumbres de Monterrey" });
        }
    }
}
