using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel;
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

    private Dependency() : base(null!)
    {
        AssignmentId = null!;
        DependOnAssignmentId = null!;
    }

    public AssignmentId AssignmentId { get; private set; }
    public AssignmentId DependOnAssignmentId { get; private set; }

    public Assignment Assignment { get; private set; } = null!;
    public Assignment DependOnAssignment { get; private set; } = null!;

    public static Dependency Create(AssignmentId assignmentId, AssignmentId dependOnAssignmentIdId)
    {
        return new Dependency(DependencyId.CreateUnique(), assignmentId, dependOnAssignmentIdId);
    }
}