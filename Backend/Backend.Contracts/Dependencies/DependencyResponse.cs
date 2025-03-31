namespace Backend.Contracts.Dependencies;

public record DependencyResponse(
    string Id,
    string TaskId,
    string DependencyTaskId
);