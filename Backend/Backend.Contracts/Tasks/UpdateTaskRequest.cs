namespace Backend.Contracts.Tasks;

public record UpdateTaskRequest(
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate
);