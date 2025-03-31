using Backend.Domain.Common.Models;

namespace Backend.Domain.TaskAggregate.ValueObjects;

public class Status : ValueObject
{
    public static readonly Status Pending = new("Pending");
    public static readonly Status InProgress = new("In Progress");
    public static readonly Status Completed = new("Completed");

    private Status(string value)
    {
        Value = value;
    }

    private string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}