namespace NatureAPI.Model.Entities;

public class Amenity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<PlaceAmenity> PlaceAmenities { get; set; } = new List<PlaceAmenity>();
}
