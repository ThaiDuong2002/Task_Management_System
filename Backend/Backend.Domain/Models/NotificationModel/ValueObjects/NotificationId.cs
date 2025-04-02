using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.NotificationModel.ValueObjects;

public class NotificationId : ValueObject
{
    private NotificationId(Guid value)
    {
        Value = value;
    }

    private NotificationId()
    {
    }

    public Guid Value { get; }

    public static NotificationId CreateUnique()
    {
        return new NotificationId(Guid.NewGuid());
    }

    public static NotificationId Create(Guid value)
    {
        return new NotificationId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}