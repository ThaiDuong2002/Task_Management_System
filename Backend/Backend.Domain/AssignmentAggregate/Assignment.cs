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

    public string Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; set; }

    public static Assignment Create(string title, string? description, Status status, Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt)
    {
        return new Assignment(AssignmentId.CreateUnique(), title, description, status, priority, dueDate, createdAt,
            updatedAt);
    }

    public void Update(string title, string? description, Status status, Priority priority,
        DateTime dueDate, DateTime updatedAt)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        UpdatedAt = updatedAt;
    }
}