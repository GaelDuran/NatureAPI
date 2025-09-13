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
        modelBuilder.Entity<Place>().HasData(Place.GetSeedPlaces());
        // Seed de Trail
        modelBuilder.Entity<Trail>().HasData(Trail.GetSeedTrails());
        // Seed de Photo
        modelBuilder.Entity<Photo>().HasData(Photo.GetSeedPhotos());

        // Seed de PlaceAmenity
        modelBuilder.Entity<PlaceAmenity>().HasData(
            new PlaceAmenity { PlaceId = 1, AmenityId = 1 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 2 },
            new PlaceAmenity { PlaceId = 1, AmenityId = 4 },
            new PlaceAmenity { PlaceId = 2, AmenityId = 3 }
        );
    }
}
