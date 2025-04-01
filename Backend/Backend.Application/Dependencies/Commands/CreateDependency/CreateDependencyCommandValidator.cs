using FluentValidation;

namespace Backend.Application.Dependencies.Commands.CreateDependency;

public class CreateDependencyCommandValidator : AbstractValidator<CreateDependencyCommand>
{
    public CreateDependencyCommandValidator()
    {
        RuleFor(x => x.AssignmentId)
            .NotEmpty()
            .WithMessage("Assignment ID is required.");

        RuleFor(x => x.DependOnAssignmentId)
            .NotEmpty()
            .WithMessage("Dependency Assignment ID is required.");
    }
}