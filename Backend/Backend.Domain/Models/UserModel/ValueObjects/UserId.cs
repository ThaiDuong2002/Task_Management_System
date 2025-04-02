using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.UserModel.ValueObjects;

public class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    private UserId()
    {
    }

    public Guid Value { get; }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}