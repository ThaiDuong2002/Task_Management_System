using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel.ValueObjects;

namespace Backend.Domain.Models.DependencyModel;

public class Dependency : Entity<DependencyId>
{
    private Dependency(DependencyId dependencyId, AssignmentId assignmentId,
        AssignmentId dependOnAssignmentIdId) : base(
        dependencyId)
    {
        AssignmentId = assignmentId;
        DependOnAssignmentId = dependOnAssignmentIdId;
    }

    public AssignmentId AssignmentId { get; }
    public AssignmentId DependOnAssignmentId { get; }

    public static Dependency Create(AssignmentId assignmentId, AssignmentId dependOnAssignmentIdId)
    {
        return new Dependency(DependencyId.CreateUnique(), assignmentId, dependOnAssignmentIdId);
    }
}