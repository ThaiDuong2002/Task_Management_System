using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;

namespace Backend.Domain.Models.AssignmentModel;

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
    
    private List<Dependency.Dependency> _dependencies = new();

    public static Assignment Create(string title, string? description, Status status, Priority priority,
        DateTime dueDate)
    {
        return new Assignment(AssignmentId.CreateUnique(), title, description, status, priority, dueDate,
            DateTime.UtcNow,
            DateTime.UtcNow);
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