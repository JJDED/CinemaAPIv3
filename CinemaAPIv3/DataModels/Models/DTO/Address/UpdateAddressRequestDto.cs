namespace DataModels.Models.DTO.Address;

public class UpdateAddressRequestDto
{
    public int AddressId { get; set; }
    public string AddressName { get; set; } = null!;

    // Navigation Properties
    public int PostalCodeId { get; set; }
}
