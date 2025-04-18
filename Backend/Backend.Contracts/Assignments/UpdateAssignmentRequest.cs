namespace Backend.Contracts.Assignments;

public record UpdateAssignmentRequest(
    string? Title,
    string? Description,
    string? Status,
    string? Priority,
    DateTime? DueDate
);