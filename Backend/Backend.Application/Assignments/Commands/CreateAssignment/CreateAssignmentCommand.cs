namespace Backend.Application.Assignments.Commands.CreateAssignment;

public record CreateAssignmentCommand(
    string Title,
    string Description,
    string Status,
    string Priority,
    DateTime DueDate
);