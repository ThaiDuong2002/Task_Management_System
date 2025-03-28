using Backend.Domain.Common.Models;

namespace Backend.Domain.TaskDependency.ValueObjects;

public class TaskDependencyId : ValueObject
{
    private TaskDependencyId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TaskDependencyId CreateUnique()
    {
        return new TaskDependencyId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}