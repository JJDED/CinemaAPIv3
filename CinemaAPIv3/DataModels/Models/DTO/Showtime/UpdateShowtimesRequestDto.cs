namespace DataModels.Models.DTO.Showtime;

public class UpdateShowtimesRequestDto
{
    public int ShowtimeId { get; set; }
    public int MovieId { get; set; }
    public int TheaterId { get; set; }
    public DateTime Showtime { get; set; }
}
