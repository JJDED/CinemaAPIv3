using DataModels.Models.Domain;
using DataModels.Models.DTO.Genre;

namespace DataModels.Models.DTO.Movie;

public class AddMovieRequestDto
{
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public int ReleaseYear { get; set; }
    // public decimal Rating { get; set; }
    public List<int> GenreIds { get; set; } = new List<int>();
    //public int GenreId { get; set; }
}
