using Backend.Domain.Common.Models;

namespace Backend.Domain.AssignmentAggregate.ValueObjects;

public sealed class AssignmentId : ValueObject
{
    private AssignmentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static AssignmentId CreateUnique()
    {
        return new AssignmentId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public Guid GetValue()
    {
        return Value;
    }
}