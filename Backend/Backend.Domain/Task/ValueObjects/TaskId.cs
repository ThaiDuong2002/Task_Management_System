using Backend.Domain.Common.Models;

namespace Backend.Domain.Task.ValueObjects;

public sealed class TaskId : ValueObject
{
    private TaskId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static TaskId CreateUnique()
    {
        return new TaskId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}