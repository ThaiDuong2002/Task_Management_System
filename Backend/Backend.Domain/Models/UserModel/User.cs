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

    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}