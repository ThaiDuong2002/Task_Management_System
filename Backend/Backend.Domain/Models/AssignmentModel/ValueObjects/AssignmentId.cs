using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.AssignmentModel.ValueObjects;

public sealed class AssignmentId : ValueObject
{
    private AssignmentId(Guid value)
    {
        Value = value;
    }

    private AssignmentId()
    {
    }

    public Guid Value { get; }

    public static AssignmentId CreateUnique()
    {
        return new AssignmentId(Guid.NewGuid());
    }

    public static AssignmentId Create(Guid value)
    {
        return new AssignmentId(value);
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