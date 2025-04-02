using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.UserModel.ValueObjects;

namespace Backend.Domain.Models.UserModel;

public class User : AggregateRoot<UserId>
{
    private readonly List<Assignment> _assignments = new();

    private User(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() : base(null!)
    {
        FirstName = null!;
        LastName = null!;
        Email = null!;
        Password = null!;
    }

    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}