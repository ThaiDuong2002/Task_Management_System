using Backend.Domain.Common.Models;

namespace Backend.Domain.Models.AssignmentModel.ValueObjects;

public class Status : ValueObject
{
    public static readonly Status Pending = new("Pending");
    public static readonly Status InProgress = new("In progress");
    public static readonly Status Completed = new("Completed");
    public static readonly Status Default = Pending;

    private Status(string value)
    {
        Value = value;
    }

    private Status()
    {
        Value = Default.Value;
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
            "Pending" => Pending,
            "In progress" => InProgress,
            "Completed" => Completed,
            _ => Default
        };
    }
}