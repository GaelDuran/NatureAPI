namespace NatureAPI.Model.Entities;

public class Photo
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Url { get; set; } = null!;
    public string? Description { get; set; }

    public Place Place { get; set; } = null!;
    public static List<Photo> GetSeedPhotos() => new List<Photo>
    {
        new Photo
        {
            Id = 1,
            PlaceId = 1,
            Url = "https://www.gob.mx/cms/uploads/image/file/418763/20-4.jpg",
            Description = "Parque Nacional El Chico en Hidalgo"
        },
        new Photo
        {
            Id = 2,
            PlaceId = 2,
            Url = "https://chihuahua.gob.mx/sites/default/files/grupos/user599/cascada_de_basaseachi_2.jpg",
            Description = "Cascada de Basaseachic en temporada de lluvias"
        },
        new Photo
        {
            Id = 3,
            PlaceId = 3,
            Url = "https://programadestinosmexico.com/wp-content/uploads/2023/10/Mirador-Pena-del-Cuervo.jpg",
            Description = "Mirador Peña del Cuervo en la Sierra de Órganos"
        },
        new Photo
        {
            Id = 4,
            PlaceId = 4,
            Url = "https://elgiroscopo.es/wp-content/uploads/2018/11/entrada_yacimiento_tepozteco.jpg",
            Description = "Entrada y sendero al Tepozteco"
        },
        new Photo
        {
            Id = 5,
            PlaceId = 5,
            Url = "https://www.gob.mx/cms/uploads/article/main_image/28051/blog_PNCM.jpg",
            Description = "Parque Nacional Cumbres de Monterrey"
        }
    };
}
