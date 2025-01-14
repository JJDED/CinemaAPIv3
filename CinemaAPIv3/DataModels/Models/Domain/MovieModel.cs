namespace DataModels.Models.Domain;

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public int ReleaseYear { get; set; }

    //public decimal Rating { get; set; }
    //public int GenreId { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; } = [];

    // Foreign Key
    //public int ShowtimesId { get; set; }
    //public List<ShowtimesModel> Showtimes { get; set; } = new List<ShowtimesModel>();
}
