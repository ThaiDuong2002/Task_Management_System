namespace Backend.Contracts.Dependencies;

public record DependencyResponse(
    string Id,
    string AssignmentId,
    string DependOnAssignmentId
);