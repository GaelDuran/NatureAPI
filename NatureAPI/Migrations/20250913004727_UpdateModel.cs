using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatureAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
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
                    { 2, false, "Cascada", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "La segunda cascada más alta de México, ubicada en la Sierra Tarahumara.", 1800, 30.0, 28.198599999999999, -108.2286, "Cascada de Basaseachic", "09:00-17:00" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Description", "PlaceId", "Url" },
                values: new object[,]
                {
                    { 1, "Vista panorámica del Parque Nacional El Chico", 1, "https://upload.wikimedia.org/wikipedia/commons/6/6e/El_Chico_National_Park.jpg" },
                    { 2, "Cascada de Basaseachic en temporada de lluvias", 2, "https://upload.wikimedia.org/wikipedia/commons/3/3d/Basaseachic_Falls.jpg" }
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
                    { 2, "Fácil", 2.0, 60, false, "Sendero a la Cascada", "28.1986,-108.2286;28.2000,-108.2300", 2 }
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
        }
    }
}
