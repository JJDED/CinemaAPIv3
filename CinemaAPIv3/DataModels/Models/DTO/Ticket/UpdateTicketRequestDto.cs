namespace DataModels.Models.DTO.Ticket;

public class UpdateTicketRequestDto
{
    public int Id { get; set; }
    public int SeatId { get; set; }
    public DateTime PurchaseDate { get; set; }

    // Foreign keys
    public int ShowtimeId { get; set; }
    public int UserId { get; set; }
}
