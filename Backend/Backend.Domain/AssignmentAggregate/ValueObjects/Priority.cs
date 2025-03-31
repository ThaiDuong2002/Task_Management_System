using Backend.Domain.Common.Models;

namespace Backend.Domain.AssignmentAggregate.ValueObjects;

public class Priority : ValueObject
{
    private Priority(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Priority Create(string? value)
    {
        return value switch
        {
            "Low" => new Priority("Low"),
            "Medium" => new Priority("Medium"),
            "High" => new Priority("High"),
            _ => new Priority("Medium")
        };
    }
}