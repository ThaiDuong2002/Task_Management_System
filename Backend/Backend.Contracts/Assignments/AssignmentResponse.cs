namespace Backend.Contracts.Assignments;

public record AssignmentResponse(
    string Id,
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate
);