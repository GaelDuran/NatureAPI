namespace NatureAPI.Model.DTOs;

public class PlaceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int ElevationMeters { get; set; }
    public bool Accessible { get; set; }
    public double EntryFee { get; set; }
    public string OpeningHours { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<TrailDto> Trails { get; set; } = new List<TrailDto>();
    public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
    public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    public List<AmenityDto> Amenities { get; set; } = new List<AmenityDto>();
}

