using FluentValidation;

namespace Backend.Application.Assignments.Commands.CreateAssignment;

public class CreateAssignmentCommandValidator : AbstractValidator<CreateAssignmentCommand>
{
    public CreateAssignmentCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => x.Description != null)
            .WithMessage("Description cannot be empty.");

        RuleFor(x => x.Status)
            .Must(status => status == null || new[] { "Pending", "In progress", "Completed" }
                .Contains(status))
            .WithMessage("Status must be 'Pending', 'In progress', or 'Completed'.");

        RuleFor(x => x.Priority)
            .Must(priority => priority == null || new[] { "Low", "Medium", "High" }
                .Contains(priority))
            .WithMessage("Priority must be 'Low', 'Medium', or 'High'.");

        RuleFor(x => x.DueDate)
            .NotEmpty()
            .WithMessage("Due date is required.")
            .Must(date => date > DateTime.UtcNow)
            .WithMessage("Due date must be in the future.");
        ;
    }
}