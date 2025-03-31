using Backend.Domain.Common.Models;
using Backend.Domain.DependencyAggregate.ValueObjects;
using Backend.Domain.TaskAggregate.ValueObjects;

namespace Backend.Domain.DependencyAggregate;

public class Dependency : Entity<DependencyId>
{
    private Dependency(DependencyId dependencyId, TaskId taskId, TaskId dependentTaskId) : base(
        dependencyId)
    {
        TaskId = taskId;
        DependentTaskId = dependentTaskId;
    }

    public TaskId TaskId { get; }
    public TaskId DependentTaskId { get; }

    public static Dependency Create(TaskId taskId, TaskId dependentTaskId)
    {
        return new Dependency(DependencyId.CreateUnique(), taskId, dependentTaskId);
    }
}