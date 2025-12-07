using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatureAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baños" },
                    { 2, "Estacionamiento" },
                    { 3, "Mirador" },
                    { 4, "Área de picnic" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Accessible", "Category", "CreatedAt", "Description", "ElevationMeters", "EntryFee", "Latitude", "Longitude", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1, true, "Parque", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uno de los parques nacionales más antiguos de México, ideal para senderismo y camping.", 2600, 40.0, 20.216699999999999, -98.7333, "Parque Nacional El Chico", "08:00-18:00" },
                    { 2, false, "Cascada", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "La segunda cascada más alta de México, ubicada en la Sierra Tarahumara.", 1800, 30.0, 28.198599999999999, -108.2286, "Cascada de Basaseachic", "09:00-17:00" },
                    { 3, true, "Mirador", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirador panorámico en la Sierra de Órganos, ideal para fotografía y observación de paisajes.", 2400, 25.0, 23.0167, -103.5167, "Mirador Peña del Cuervo", "07:00-19:00" },
                    { 4, false, "Sendero", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta de senderismo que lleva a la cima del cerro Tepozteco, con vistas espectaculares.", 2200, 50.0, 18.973099999999999, -99.094200000000001, "Sendero del Tepozteco", "06:00-18:00" },
                    { 5, true, "Parque", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Área natural protegida con montañas, cañones y cascadas, ideal para actividades al aire libre.", 2100, 35.0, 25.683299999999999, -100.3167, "Parque Nacional Cumbres de Monterrey", "08:00-20:00" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Description", "PlaceId", "Url" },
                values: new object[,]
                {
                    { 1, "Parque Nacional El Chico en Hidalgo", 1, "https://www.gob.mx/cms/uploads/image/file/418763/20-4.jpg" },
                    { 2, "Cascada de Basaseachic en temporada de lluvias", 2, "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg" },
                    { 3, "Mirador Peña del Cuervo en la Sierra de Órganos", 3, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg" },
                    { 4, "Entrada y sendero al Tepozteco", 4, "https://elgiroscopo.es/wp-content/uploads/2018/11/entrada_yacimiento_tepozteco.jpg" },
                    { 5, "Parque Nacional Cumbres de Monterrey", 5, "https://www.gob.mx/cms/uploads/article/main_image/28051/blog_PNCM.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PlaceAmenities",
                columns: new[] { "AmenityId", "PlaceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Difficulty", "DistanceKm", "EstimatedTimeMinutes", "IsLoop", "Name", "Path", "PlaceId" },
                values: new object[,]
                {
                    { 1, "Media", 4.5, 120, true, "Sendero Las Monjas", "20.2167,-98.7333;20.2200,-98.7300", 1 },
                    { 2, "Fácil", 2.0, 60, false, "Sendero a la Cascada", "28.1986,-108.2286;28.2000,-108.2300", 2 },
                    { 3, "Fácil", 1.2, 40, true, "Ruta Peña del Cuervo", "23.0167,-103.5167;23.0180,-103.5200", 3 },
                    { 4, "Difícil", 2.5, 90, false, "Ascenso al Tepozteco", "18.9731,-99.0942;18.9750,-99.0950", 4 },
                    { 5, "Media", 5.0, 180, true, "Cañón de la Huasteca", "25.6833,-100.3167;25.6900,-100.3200", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlaceAmenities",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenities",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenities",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PlaceAmenities",
                keyColumns: new[] { "AmenityId", "PlaceId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
