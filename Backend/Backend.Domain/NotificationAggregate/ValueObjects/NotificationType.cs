using Backend.Domain.Common.Models;

namespace Backend.Domain.NotificationAggregate.ValueObjects;

public class NotificationType : ValueObject
{
    public static readonly NotificationType Upcoming = new("Upcoming");
    public static readonly NotificationType Overdue = new("Overdue");

    private NotificationType(string value)
    {
        Value = value;
    }

    private string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}