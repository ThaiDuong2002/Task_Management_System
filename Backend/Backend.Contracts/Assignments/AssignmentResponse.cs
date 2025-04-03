namespace Backend.Contracts.Assignments;

public record AssignmentResponse(
    Guid Id,
    string UserId,
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate,
    DateTime CreatedAt,
    DateTime UpdatedAt
);