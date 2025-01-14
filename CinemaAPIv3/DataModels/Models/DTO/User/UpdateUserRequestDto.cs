namespace DataModels.Models.DTO.User;

public class UpdateUserRequestDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public int PostalCodeId { get; set; }
}
