namespace Backend.Contracts.Dependencies;

public record CreateDependencyRequest(
    Guid DependOnAssignmentId
);