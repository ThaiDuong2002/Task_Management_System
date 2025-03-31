using Backend.Domain.Common.Models;

namespace Backend.Domain.AssignmentAggregate.ValueObjects;

public class Status : ValueObject
{
    private Status(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Status Create(string? value)
    {
        return value switch
        {
            "Pending" => new Status("Pending"),
            "In Progress" => new Status("In Progress"),
            "Completed" => new Status("Completed"),
            _ => new Status("Pending")
        };
    }
}