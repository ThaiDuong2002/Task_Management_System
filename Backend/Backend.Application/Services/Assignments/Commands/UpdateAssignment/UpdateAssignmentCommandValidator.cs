using FluentValidation;

namespace Backend.Application.Services.Assignments.Commands.UpdateAssignment;

public class UpdateAssignmentCommandValidator : AbstractValidator<UpdateAssignmentCommand>
{
    public UpdateAssignmentCommandValidator()
    {
        RuleFor(x => x.Title)
            .Must(title => title == null || title.Length > 0)
            .WithMessage("Title cannot be empty.");
        
        RuleFor(x => x.Status)
            .Must(status => status == null || new[] { "Pending", "In progress", "Completed" }
                .Contains(status))
            .WithMessage("Status must be 'Pending', 'In progress', or 'Completed'.");

        RuleFor(x => x.Priority)
            .Must(priority => priority == null || new[] { "Low", "Medium", "High" }
                .Contains(priority))
            .WithMessage("Priority must be 'Low', 'Medium', or 'High'.");

        RuleFor(x => x.DueDate)
            .Must(date => date == null || date > DateTime.UtcNow)
            .WithMessage("Due date must be in the future.");
        ;
    }
}