using Backend.Domain.Common.Models;

namespace Backend.Domain.AssignmentAggregate.ValueObjects;

public class Priority : ValueObject
{
    public static readonly Priority Low = new("Low");
    public static readonly Priority Medium = new("Medium");
    public static readonly Priority High = new("High");

    private Priority(string value)
    {
        Value = value;
    }

    private string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}