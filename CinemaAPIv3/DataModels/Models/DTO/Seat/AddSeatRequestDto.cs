namespace DataModels.Models.DTO.Seat;

public class AddSeatRequestDto
{
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }

    // Foreign key
    public int HallId { get; set; }

    // Navigation property
    // public Theater Theater { get; set; } = null!;
}
