using Backend.Domain.Models.AssignmentModel;
using Microsoft.AspNetCore.Identity;

namespace Backend.Infrastructure.Authentication.Identity;

public class UserIdentity : IdentityUser<Guid>
{
    private readonly List<Assignment> _assignments = new();

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();
}