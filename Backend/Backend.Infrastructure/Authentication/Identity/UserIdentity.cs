using Backend.Domain.Models.AssignmentModel;
using Microsoft.AspNetCore.Identity;

namespace Backend.Infrastructure.Authentication.Identity;

public class UserIdentity : IdentityUser<Guid>
{
    private readonly List<Assignment> _assignments = new();

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();
}