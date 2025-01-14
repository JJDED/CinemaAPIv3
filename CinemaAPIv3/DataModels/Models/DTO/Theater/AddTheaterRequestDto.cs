using DataModels.Models.Domain;

namespace DataModels.Models.DTO.Theater;

public class AddTheaterRequestDto
{
    public string TheaterName { get; set; } = null!;
    public string? Location { get; set; }
    public int Capacity { get; set; }
    public AddressModel? Address { get; set; }
    public int AddressId { get; set; }
}
