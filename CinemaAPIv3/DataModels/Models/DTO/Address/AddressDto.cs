namespace DataModels.Models.DTO.Address;

public class AddressDto
{
    public string AddressName { get; set; } = null!;

    // Navigation property
    public int PostalCodeId { get; set; }
}
