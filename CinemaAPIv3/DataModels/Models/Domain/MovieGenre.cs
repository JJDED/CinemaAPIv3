namespace DataModels.Models.Domain;

public class MovieGenre
{
    public int MovieId { get; set; }
    public MovieModel Movie { get; set; }

    public int GenreId { get; set; }
    public GenreModel Genre { get; set; }
}
