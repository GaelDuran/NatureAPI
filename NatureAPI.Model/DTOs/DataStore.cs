using NatureAPI.Model.DTOs;

public static class DataStore
{
    public static List<PlaceDto> Places { get; } = new()
    {
        new PlaceDto
        {
            Name = "Parque Central",
            Description = "Un lugar bonito para pasear",
            Category = "Parque",
            OpeningHours = "08:00 - 20:00",
            Trails = new List<TrailDto>
            {
                new TrailDto { Name = "Sendero 1", Difficulty = "Fácil", Path = "Circular" }
            },
            Photos = new List<PhotoDto>(),
            Reviews = new List<ReviewDto>(),
            Amenities = new List<AmenityDto>()
        },
        new PlaceDto
        {
            Name = "Laguna Azul",
            Description = "Ideal para picnic y kayak",
            Category = "Naturaleza",
            OpeningHours = "06:00 - 19:00",
            Trails = new List<TrailDto>(),
            Photos = new List<PhotoDto>(),
            Reviews = new List<ReviewDto>(),
            Amenities = new List<AmenityDto>()
        }
    };
}