namespace DataModels.Models.Domain;

public class GenreModel
{
    public int Id { get; set; }
    public string GenreName { get; set; }

    // Navigation Properties
    //public int MovieId { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; } = [];

}
