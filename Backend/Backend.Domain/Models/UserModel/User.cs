namespace Backend.Domain.Models.UserModel;

public class User
{
    public Guid? Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}