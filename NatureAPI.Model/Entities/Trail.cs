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
}
