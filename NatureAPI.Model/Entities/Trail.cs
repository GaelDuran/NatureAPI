namespace NatureAPI.Model.Entities;

public class Trail
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Name { get; set; } = null!;
    public double DistanceKm { get; set; }
    public int EstimatedTimeMinutes { get; set; }
    public string Difficulty { get; set; } = null!;
    public string Path { get; set; } = null!;
    public bool IsLoop { get; set; }

    public Place Place { get; set; } = null!;

    public static List<Trail> GetSeedTrails() => new List<Trail>
    {
        new Trail
        {
            Id = 1,
            PlaceId = 1,
            Name = "Sendero Las Monjas",
            DistanceKm = 4.5,
            EstimatedTimeMinutes = 120,
            Difficulty = "Media",
            Path = "20.2167,-98.7333;20.2200,-98.7300",
            IsLoop = true
        },
        new Trail
        {
            Id = 2,
            PlaceId = 2,
            Name = "Sendero a la Cascada",
            DistanceKm = 2.0,
            EstimatedTimeMinutes = 60,
            Difficulty = "Fácil",
            Path = "28.1986,-108.2286;28.2000,-108.2300",
            IsLoop = false
        },
        new Trail
        {
            Id = 3,
            PlaceId = 3,
            Name = "Ruta Peña del Cuervo",
            DistanceKm = 1.2,
            EstimatedTimeMinutes = 40,
            Difficulty = "Fácil",
            Path = "23.0167,-103.5167;23.0180,-103.5200",
            IsLoop = true
        },
        new Trail
        {
            Id = 4,
            PlaceId = 4,
            Name = "Ascenso al Tepozteco",
            DistanceKm = 2.5,
            EstimatedTimeMinutes = 90,
            Difficulty = "Difícil",
            Path = "18.9731,-99.0942;18.9750,-99.0950",
            IsLoop = false
        },
        new Trail
        {
            Id = 5,
            PlaceId = 5,
            Name = "Cañón de la Huasteca",
            DistanceKm = 5.0,
            EstimatedTimeMinutes = 180,
            Difficulty = "Media",
            Path = "25.6833,-100.3167;25.6900,-100.3200",
            IsLoop = true
        }
    };
}
