using FluentValidation;

namespace Backend.Application.Services.Notifications.Commands.CreateNotification;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");

        RuleFor(x => x.AssignmentId)
            .NotEmpty()
            .WithMessage("Assignment ID is required.");

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message is required.");

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type is required.")
            .Must(type => type == "Upcoming" || type == "Overdue")
            .WithMessage("Type must be 'Upcoming' or 'Overdue'.");
    }
}