using DataModels.Models.Domain;

namespace DataModels.Models.DTO.Hall;

public class HallDto
{
    public int Id { get; set; }
    public int SeatColumn { get; set; }
    public int SeatRow { get; set; }

    // Foreign key
    public List<SeatModel> Seats { get; set; } = new List<SeatModel>();
}
