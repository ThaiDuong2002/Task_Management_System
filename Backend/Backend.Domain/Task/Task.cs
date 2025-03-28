using Backend.Domain.Common.Models;
using Backend.Domain.Task.ValueObjects;

namespace Backend.Domain.Task;

public class Task : AggregateRoot<TaskId>
{
    public Task(TaskId id) : base(id)
    {
    }
}