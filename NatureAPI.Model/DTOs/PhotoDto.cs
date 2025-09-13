namespace NatureAPI.Model.DTOs;

/// <summary>
/// Imagen asociada a un lugar natural.
/// </summary>
public class PhotoDto
{
    /// <summary>
    /// Identificador de la foto.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// URL de la imagen. Ejemplo: https://upload.wikimedia.org/wikipedia/commons/6/6e/El_Chico_National_Park.jpg
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// Descripción opcional de la imagen.
    /// </summary>
    public string? Description { get; set; }
}
