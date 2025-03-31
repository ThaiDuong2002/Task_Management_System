using Backend.Domain.Common.Models;

namespace Backend.Domain.NotificationAggregate.ValueObjects;

public class NotificationId : ValueObject
{
    private NotificationId(Guid value)
    {
        Value = value;
    }

    private Guid Value { get; }

    public static NotificationId CreateUnique()
    {
        return new NotificationId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}