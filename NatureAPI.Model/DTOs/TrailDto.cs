namespace NatureAPI.Model.DTOs;

public class TrailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double DistanceKm { get; set; }
    public int EstimatedTimeMinutes { get; set; }
    public string Difficulty { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public bool IsLoop { get; set; }
}

