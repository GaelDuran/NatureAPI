namespace NatureAPI.Model.Entities;

public class Review
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Author { get; set; } = null!;
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public Place Place { get; set; } = null!;
}
