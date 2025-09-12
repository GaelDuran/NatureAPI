namespace NatureAPI.Model.Entities;

public class PlaceAmenity
{
    public int PlaceId { get; set; }
    public int AmenityId { get; set; }

    public Place Place { get; set; } = null!;
    public Amenity Amenity { get; set; } = null!;
}
