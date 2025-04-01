using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.AssignmentModel.ValueObjects;

public class Priority : ValueObject
{
    public static readonly Priority Low = new("Low");
    public static readonly Priority Medium = new("Medium");
    public static readonly Priority High = new("High");
    public static readonly Priority Default = Medium;

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
            "Low" => Low,
            "Medium" => Medium,
            "High" => High,
            _ => Default
        };
    }
}