// csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatureAPI.Data;
using NatureAPI.Model.Entities;
using NatureAPI.Model.DTOs;
using NatureAPI.Services;

namespace NatureAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlacesController : ControllerBase
{
    private readonly NatureDbContext _context;
    public PlacesController(NatureDbContext context)
    {
        _context = context;
    }

    // GET /api/places?category=Parque&difficulty=Media
    [HttpGet]
    public async Task<IActionResult> GetPlaces([FromQuery] string? category, [FromQuery] string? difficulty)
    {
        var query = _context.Places
            .Include(p => p.Trails)
            .Include(p => p.Photos)
            .Include(p => p.Reviews)
            .Include(p => p.PlaceAmenities).ThenInclude(pa => pa.Amenity)
            .AsQueryable();

        if (!string.IsNullOrEmpty(category))
            query = query.Where(p => p.Category == category);

        if (!string.IsNullOrEmpty(difficulty))
            query = query.Where(p => p.Trails.Any(t => t.Difficulty == difficulty));

        var places = await query.ToListAsync();
        var placeDtos = places.Select(p => new PlaceDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Category = p.Category,
            Latitude = p.Latitude,
            Longitude = p.Longitude,
            ElevationMeters = p.ElevationMeters,
            Accessible = p.Accessible,
            EntryFee = p.EntryFee,
            OpeningHours = p.OpeningHours,
            CreatedAt = p.CreatedAt,
            Trails = p.Trails.Select(t => new TrailDto
            {
                Id = t.Id,
                Name = t.Name,
                DistanceKm = t.DistanceKm,
                EstimatedTimeMinutes = t.EstimatedTimeMinutes,
                Difficulty = t.Difficulty,
                Path = t.Path,
                IsLoop = t.IsLoop
            }).ToList(),
            Photos = p.Photos.Select(ph => new PhotoDto
            {
                Id = ph.Id,
                Url = ph.Url,
                Description = ph.Description
            }).ToList(),
            Reviews = p.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Author = r.Author,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList(),
            Amenities = p.PlaceAmenities.Select(pa => new AmenityDto
            {
                Id = pa.Amenity.Id,
                Name = pa.Amenity.Name
            }).ToList()
        }).ToList();
        return Ok(placeDtos);
    }

    // GET /api/places/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlace(int id)
    {
        var place = await _context.Places
            .Include(p => p.Trails)
            .Include(p => p.Photos)
            .Include(p => p.Reviews)
            .Include(p => p.PlaceAmenities).ThenInclude(pa => pa.Amenity)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (place == null)
            return NotFound();

        var placeDto = new PlaceDto
        {
            Id = place.Id,
            Name = place.Name,
            Description = place.Description,
            Category = place.Category,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            ElevationMeters = place.ElevationMeters,
            Accessible = place.Accessible,
            EntryFee = place.EntryFee,
            OpeningHours = place.OpeningHours,
            CreatedAt = place.CreatedAt,
            Trails = place.Trails.Select(t => new TrailDto
            {
                Id = t.Id,
                Name = t.Name,
                DistanceKm = t.DistanceKm,
                EstimatedTimeMinutes = t.EstimatedTimeMinutes,
                Difficulty = t.Difficulty,
                Path = t.Path,
                IsLoop = t.IsLoop
            }).ToList(),
            Photos = place.Photos.Select(ph => new PhotoDto
            {
                Id = ph.Id,
                Url = ph.Url,
                Description = ph.Description
            }).ToList(),
            Reviews = place.Reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Author = r.Author,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList(),
            Amenities = place.PlaceAmenities.Select(pa => new AmenityDto
            {
                Id = pa.Amenity.Id,
                Name = pa.Amenity.Name
            }).ToList()
        };
        return Ok(placeDto);
    }

    // POST /api/places
    [HttpPost]
    public async Task<IActionResult> CreatePlace([FromBody] Place place)
    {
        if (place.Latitude < -90 || place.Latitude > 90 || place.Longitude < -180 || place.Longitude > 180)
        {
            return BadRequest("Coordenadas de latitud o longitud inválidas.");
        }
        place.CreatedAt = DateTime.UtcNow;
        _context.Places.Add(place);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlace), new { id = place.Id }, place);
    }

    // GET /api/places/{id}/summary
    [HttpGet("{id}/summary")]
    public async Task<IActionResult> GetPlaceSummary(int id, [FromServices] OpenAIService ai)
    {
        var place = await _context.Places.FirstOrDefaultAsync(p => p.Id == id);
        if (place == null)
            return NotFound();

        var summary = await ai.SummarizePlace(place.Name, place.Description ?? string.Empty);
        return Ok(new { summary });
    }
}
