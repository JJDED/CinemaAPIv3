namespace DataModels.Models.DTO.Ticket;

public class TicketsDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShowtimeId { get; set; }
    public int SeatId { get; set; }
    public DateTime PurchaseDate { get; set; }
}
