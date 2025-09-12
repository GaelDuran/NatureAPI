namespace NatureAPI.Model.Entities;

public class Photo
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Url { get; set; } = null!;
    public string? Description { get; set; }

    public Place Place { get; set; } = null!;
}
