namespace DataModels.Models.Domain;

public class AddressModel
{
    public int Id { get; set; }
    public string AddressName { get; set; } = null!;

    // Navigation Properties
    public int PostalCodeId { get; set; }
}
