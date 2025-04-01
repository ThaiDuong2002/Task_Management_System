using FluentValidation;

namespace Backend.Application.Assignments.Queries.GetAssignment;

public class GetAssignmentQueryValidation : AbstractValidator<GetAssignmentQuery>
{
    public GetAssignmentQueryValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Assignment ID cannot be empty.");
    }
}