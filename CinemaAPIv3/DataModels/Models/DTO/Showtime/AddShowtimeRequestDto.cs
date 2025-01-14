namespace DataModels.Models.DTO.Showtime;

public class AddShowtimeRequestDto
{
    public int MovieId { get; set; }
    public int TheaterId { get; set; }
    public DateTime Showtime { get; set; }
}
