using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.NotificationModel.ValueObjects;

public class NotificationType : ValueObject
{
    public static readonly NotificationType Upcoming = new("Upcoming");
    public static readonly NotificationType Overdue = new("Overdue");
    public static readonly NotificationType Default = Upcoming;

    private NotificationType(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static NotificationType Create(string value)
    {
        return value switch
        {
            "Upcoming" => Upcoming,
            "Overdue" => Overdue,
            _ => Default
        };
    }
}