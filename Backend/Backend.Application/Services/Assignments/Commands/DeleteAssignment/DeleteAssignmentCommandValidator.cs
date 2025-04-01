using FluentValidation;

namespace Backend.Application.Services.Assignments.Commands.DeleteAssignment;

public class DeleteAssignmentCommandValidator : AbstractValidator<DeleteAssignmentCommand>
{
    public DeleteAssignmentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Assignment ID is required.");
    }
}