using DataModels.Models.Domain;

namespace DataModels.Models.DTO.Theater;

public class UpdateTheaterRequestDto
{
    public int Id { get; set; }
    public string TheaterName { get; set; }
    public string? Location { get; set; }
    public int Capacity { get; set; }
    public AddressModel? Address { get; set; }
    public int AddressId { get; set; }
}
