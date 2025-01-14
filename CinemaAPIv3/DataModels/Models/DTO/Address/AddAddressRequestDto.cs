namespace DataModels.Models.DTO.Address;

public class AddAddressRequestDto
{
    public string AddressName { get; set; } = null!;

    // Navigation Properties
    public int PostalCodeId { get; set; }
}
