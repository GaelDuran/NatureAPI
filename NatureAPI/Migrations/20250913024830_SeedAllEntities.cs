using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatureAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Parque Nacional El Chico en Hidalgo");

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Accessible", "Category", "CreatedAt", "Description", "ElevationMeters", "EntryFee", "Latitude", "Longitude", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 3, true, "Mirador", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirador panorámico en la Sierra de Órganos, ideal para fotografía y observación de paisajes.", 2400, 25.0, 23.0167, -103.5167, "Mirador Peña del Cuervo", "07:00-19:00" },
                    { 4, false, "Sendero", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruta de senderismo que lleva a la cima del cerro Tepozteco, con vistas espectaculares.", 2200, 50.0, 18.973099999999999, -99.094200000000001, "Sendero del Tepozteco", "06:00-18:00" },
                    { 5, true, "Parque", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Área natural protegida con montañas, cañones y cascadas, ideal para actividades al aire libre.", 2100, 35.0, 25.683299999999999, -100.3167, "Parque Nacional Cumbres de Monterrey", "08:00-20:00" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Description", "PlaceId", "Url" },
                values: new object[,]
                {
                    { 3, "Mirador Peña del Cuervo en la Sierra de Órganos", 3, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg" },
                    { 4, "Sendero del Tepozteco, Morelos", 4, "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg" },
                    { 5, "Parque Nacional Cumbres de Monterrey", 5, "https://www.gob.mx/cms/uploads/article/main_image/28051/blog_PNCM.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Difficulty", "DistanceKm", "EstimatedTimeMinutes", "IsLoop", "Name", "Path", "PlaceId" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Vista panorámica del Parque Nacional El Chico");
        }
    }
}
