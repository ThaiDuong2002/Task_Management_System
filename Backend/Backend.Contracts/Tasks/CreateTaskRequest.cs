namespace Backend.Contracts.Tasks;

public record CreateTaskRequest(
    string UserId,
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate
);