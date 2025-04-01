using FluentValidation;

namespace Backend.Application.Services.Dependencies.Commands.DeleteDependency;

public class DeleteDependencyCommandValidator : AbstractValidator<DeleteDependencyCommand>
{
    public DeleteDependencyCommandValidator()
    {
        RuleFor(x => x.AssignmentId)
            .NotEmpty()
            .WithMessage("Assignment ID is required.");

        RuleFor(x => x.DependOnAssignmentId)
            .NotEmpty()
            .WithMessage("Dependency Assignment ID is required.");
    }
}