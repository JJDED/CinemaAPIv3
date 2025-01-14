namespace DataModels.Models.DTO.User;

public class AddUserRequestDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PostalCodeId { get; set; }
}
