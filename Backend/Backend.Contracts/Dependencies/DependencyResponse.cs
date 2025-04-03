namespace Backend.Contracts.Dependencies;

public record DependencyResponse(
    Guid Id,
    string AssignmentId,
    string DependOnAssignmentId
);