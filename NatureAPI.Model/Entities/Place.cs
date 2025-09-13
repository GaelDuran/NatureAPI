namespace NatureAPI.Model.Entities;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int ElevationMeters { get; set; }
    public bool Accessible { get; set; }
    public double EntryFee { get; set; }
    public string OpeningHours { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public ICollection<Trail> Trails { get; set; } = new List<Trail>();
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<PlaceAmenity> PlaceAmenities { get; set; } = new List<PlaceAmenity>();

    public static List<Place> GetSeedPlaces() => new List<Place>
    {
        new Place
        {
            Id = 1,
            Name = "Parque Nacional El Chico",
            Description = "Uno de los parques nacionales más antiguos de México, ideal para senderismo y camping.",
            Category = "Parque",
            Latitude = 20.2167,
            Longitude = -98.7333,
            ElevationMeters = 2600,
            Accessible = true,
            EntryFee = 40,
            OpeningHours = "08:00-18:00",
            CreatedAt = new DateTime(2024, 1, 1)
        },
        new Place
        {
            Id = 2,
            Name = "Cascada de Basaseachic",
            Description = "La segunda cascada más alta de México, ubicada en la Sierra Tarahumara.",
            Category = "Cascada",
            Latitude = 28.1986,
            Longitude = -108.2286,
            ElevationMeters = 1800,
            Accessible = false,
            EntryFee = 30,
            OpeningHours = "09:00-17:00",
            CreatedAt = new DateTime(2024, 2, 1)
        },
        new Place
        {
            Id = 3,
            Name = "Mirador Peña del Cuervo",
            Description = "Mirador panorámico en la Sierra de Órganos, ideal para fotografía y observación de paisajes.",
            Category = "Mirador",
            Latitude = 23.0167,
            Longitude = -103.5167,
            ElevationMeters = 2400,
            Accessible = true,
            EntryFee = 25,
            OpeningHours = "07:00-19:00",
            CreatedAt = new DateTime(2024, 3, 1)
        },
        new Place
        {
            Id = 4,
            Name = "Sendero del Tepozteco",
            Description = "Ruta de senderismo que lleva a la cima del cerro Tepozteco, con vistas espectaculares.",
            Category = "Sendero",
            Latitude = 18.9731,
            Longitude = -99.0942,
            ElevationMeters = 2200,
            Accessible = false,
            EntryFee = 50,
            OpeningHours = "06:00-18:00",
            CreatedAt = new DateTime(2024, 4, 1)
        },
        new Place
        {
            Id = 5,
            Name = "Parque Nacional Cumbres de Monterrey",
            Description = "Área natural protegida con montañas, cañones y cascadas, ideal para actividades al aire libre.",
            Category = "Parque",
            Latitude = 25.6833,
            Longitude = -100.3167,
            ElevationMeters = 2100,
            Accessible = true,
            EntryFee = 35,
            OpeningHours = "08:00-20:00",
            CreatedAt = new DateTime(2024, 5, 1)
        }
    };
}
