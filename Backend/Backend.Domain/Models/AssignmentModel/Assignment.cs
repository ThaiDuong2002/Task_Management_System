using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel;

namespace Backend.Domain.Models.AssignmentModel;

public sealed class Assignment : AggregateRoot<AssignmentId>
{
    private readonly List<Dependency> _dependencies = new();

    private Assignment() : base(null!)
    {
        UserId = Guid.Empty;
        Title = null!;
        Description = null;
        Status = null!;
        Priority = null!;
        DueDate = default!;
        CreatedAt = default!;
    }

    private Assignment(AssignmentId assignmentId, Guid userId, string title, string? description, Status status,
        Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt) : base(
        assignmentId)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public IReadOnlyList<Dependency> Dependencies => _dependencies.AsReadOnly();

    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Status Status { get; private set; }
    public Priority Priority { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Assignment Create(Guid userId, string title, string? description, Status status, Priority priority,
        DateTime dueDate)
    {
        return new Assignment(AssignmentId.CreateUnique(), userId, title, description, status, priority, dueDate,
            DateTime.UtcNow, DateTime.UtcNow);
    }

    public void Update(string title, string? description, Status status, Priority priority,
        DateTime dueDate)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        UpdatedAt = DateTime.UtcNow;
    }
}