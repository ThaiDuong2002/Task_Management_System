using Backend.Domain.Common.Models;

namespace Backend.Domain.DependencyAggregate.ValueObjects;

public class DependencyId : ValueObject
{
    private DependencyId(Guid value)
    {
        Value = value;
    }

    private Guid Value { get; }

    public static DependencyId CreateUnique()
    {
        return new DependencyId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}