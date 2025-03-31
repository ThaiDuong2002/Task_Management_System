using Backend.Domain.Common.Models;
using Backend.Domain.TaskAggregate.ValueObjects;

namespace Backend.Domain.TaskAggregate;

public sealed class Task : AggregateRoot<TaskId>
{
    private Task(TaskId taskId, string title, string description, Status status, Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt) : base(
        taskId)
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
    public string Description { get; }
    public Status Status { get; }
    public Priority Priority { get; }
    public DateTime DueDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public static Task Create(string title, string description, Status status, Priority priority,
        DateTime dueDate, DateTime createdAt, DateTime updatedAt)
    {
        return new Task(TaskId.CreateUnique(), title, description, status, priority, dueDate, createdAt, updatedAt);
    }
}