namespace Backend.Contracts.Assignments;

public record CreateAssignmentRequest(
    string UserId,
    string Title,
    string? Description,
    string? Status,
    string? Priority,
    DateTime DueDate
);