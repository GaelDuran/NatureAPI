using Microsoft.EntityFrameworkCore;
using NatureAPI.Model.Entities;

namespace NatureAPI.Data;

public class NatureDbContext : DbContext
{
    public NatureDbContext(DbContextOptions<NatureDbContext> options) : base(options) { }

    public DbSet<Place> Places => Set<Place>();
    public DbSet<Trail> Trails => Set<Trail>();
    public DbSet<Photo> Photos => Set<Photo>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<PlaceAmenity> PlaceAmenities => Set<PlaceAmenity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlaceAmenity>()
            .HasKey(pa => new { pa.PlaceId, pa.AmenityId });

        modelBuilder.Entity<PlaceAmenity>()
            .HasOne(pa => pa.Place)
            .WithMany(p => p.PlaceAmenities)
            .HasForeignKey(pa => pa.PlaceId);

        modelBuilder.Entity<PlaceAmenity>()
            .HasOne(pa => pa.Amenity)
            .WithMany(a => a.PlaceAmenities)
            .HasForeignKey(pa => pa.AmenityId);

        // Seed de Amenity
        modelBuilder.Entity<Amenity>().HasData(
            new Amenity { Id = 1, Name = "Baños" },
            new Amenity { Id = 2, Name = "Estacionamiento" },
            new Amenity { Id = 3, Name = "Mirador" },
            new Amenity { Id = 4, Name = "Área de picnic" }
        );

        // Seed de Place
        modelBuilder.Entity<Place>().HasData(
            new Place {
                Id = 1,
                Name = "Parque Nacional El Chico",
                Description = "Uno de los parques nacionales más antiguos de México, ideal para senderismo y camping.",
                Category = "Parque",
                Latitude = 20.2167,
                Longitude = -98.7333,
                ElevationMeters = 2600,
                Accessible = true,
                EntryFee = 40.0,
                OpeningHours = "08:00-18:00",
                CreatedAt = new DateTime(2024, 1, 1)
            },
            new Place {
                Id = 2,
                Name = "Cascada de Basaseachic",
                Description = "La segunda cascada más alta de México, ubicada en la Sierra Tarahumara.",
                Category = "Cascada",
                Latitude = 28.1986,
                Longitude = -108.2286,
                ElevationMeters = 1800,
                Accessible = false,
                EntryFee = 30.0,
                OpeningHours = "09:00-17:00",
                CreatedAt = new DateTime(2024, 2, 1)
            }
        );

        // Seed de Trail
        modelBuilder.Entity<Trail>().HasData(
            new Trail {
                Id = 1,
                PlaceId = 1,
                Name = "Sendero Las Monjas",
                DistanceKm = 4.5,
                EstimatedTimeMinutes = 120,
                Difficulty = "Media",
                Path = "20.2167,-98.7333;20.2200,-98.7300",
                IsLoop = true
            },
            new Trail {
                Id = 2,
                PlaceId = 2,
                Name = "Sendero a la Cascada",
                DistanceKm = 2.0,
                EstimatedTimeMinutes = 60,
                Difficulty = "Fácil",
                Path = "28.1986,-108.2286;28.2000,-108.2300",
                IsLoop = false
            }
        );

        // Seed de Photo
        modelBuilder.Entity<Photo>().HasData(
            new Photo {
                Id = 1,
                PlaceId = 1,
                Url = "https://upload.wikimedia.org/wikipedia/commons/6/6e/El_Chico_National_Park.jpg",
                Description = "Vista panorámica del Parque Nacional El Chico"
            },
            new Photo {
                Id = 2,
                PlaceId = 2,
                Url = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Basaseachic_Falls.jpg",
                Description = "Cascada de Basaseachic en temporada de lluvias"
            }
        );

        // Seed de PlaceAmenity
        modelBuilder.Entity<PlaceAmenity>().HasData(
            new PlaceAmenity { PlaceId = 1, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 4 },
            new PlaceAmenity { PlaceId = 2, AmenityId = 3 }
        );
    }
}
