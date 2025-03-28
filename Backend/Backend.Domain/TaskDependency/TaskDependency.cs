using Backend.Domain.Common.Models;
using Backend.Domain.TaskDependency.ValueObjects;

namespace Backend.Domain.TaskDependency;

public class TaskDependency : Entity<TaskDependencyId>
{
    public TaskDependency(TaskDependencyId id) : base(id)
    {
    }
}