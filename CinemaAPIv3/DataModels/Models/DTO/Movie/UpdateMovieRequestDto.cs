using DataModels.Models.Domain;
using DataModels.Models.DTO.Genre;

namespace DataModels.Models.DTO.Movie;

public class UpdateMovieRequestDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public int ReleaseYear { get; set; }

    // public decimal Rating { get; set; }
    public List<GenreDto> Genres { get; set; } = new List<GenreDto>();
}
