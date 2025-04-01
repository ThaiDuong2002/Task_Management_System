using Backend.Domain.AssignmentAggregate.ValueObjects;
using Backend.Domain.Common.Models;

namespace Backend.Domain.AssignmentAggregate;

public sealed class Assignment : AggregateRoot<AssignmentId>
{
    private Assignment(AssignmentId assignmentId, string title, string? description, Status status, Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt) : base(
        assignmentId)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Title { get; }
    public string? Description { get; }
    public Status Status { get; }
    public Priority Priority { get; }
    public DateTime DueDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public static Assignment Create(string title, string? description, Status status, Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt)
    {
        return new Assignment(AssignmentId.CreateUnique(), title, description, status, priority, dueDate, createdAt,
            updatedAt);
    }

    public Assignment Update(string title, string? description, Status status, Priority priority,
        DateTime dueDate, DateTime updatedAt)
    {
        return new Assignment(Id, title, description, status, priority, dueDate, CreatedAt, updatedAt);
    }
}