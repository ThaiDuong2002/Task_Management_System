namespace Backend.Contracts.Tasks;

public record TaskResponse(
    string Id,
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate
);