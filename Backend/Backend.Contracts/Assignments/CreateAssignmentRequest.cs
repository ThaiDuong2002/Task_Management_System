namespace Backend.Contracts.Assignments;

public record CreateAssignmentRequest(
    Guid UserId,
    string Title,
    string? Description,
    string? Status,
    string? Priority,
    DateTime? DueDate
);