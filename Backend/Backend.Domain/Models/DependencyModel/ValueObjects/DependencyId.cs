using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.DependencyModel.ValueObjects;

public class DependencyId : ValueObject
{
    private DependencyId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static DependencyId CreateUnique()
    {
        return new DependencyId(Guid.NewGuid());
    }

    public static DependencyId Create(Guid value)
    {
        return new DependencyId(value);
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