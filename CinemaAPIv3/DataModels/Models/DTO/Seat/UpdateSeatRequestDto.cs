using DataModels.Models.Domain;

namespace DataModels.Models.DTO.Seat;

public class UpdateSeatRequestDto
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }

    // Foreign key
    public int TheaterID { get; set; }

    // Navigation property
    public TheaterModel Theater { get; set; } = null!;
}
