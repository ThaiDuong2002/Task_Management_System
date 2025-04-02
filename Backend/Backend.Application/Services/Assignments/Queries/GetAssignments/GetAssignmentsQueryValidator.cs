using FluentValidation;

namespace Backend.Application.Services.Assignments.Queries.GetAssignments;

public class GetAssignmentsQueryValidator : AbstractValidator<GetAssignmentsQuery>
{
    public GetAssignmentsQueryValidator()
    {
        RuleFor(x => x.Priority)
            .Must(priority => priority == null || new[] { "Low", "Medium", "High" }
                .Contains(priority))
            .WithMessage("Priority must be 'Low', 'Medium', or 'High'.");

        RuleFor(x => x.Status)
            .Must(status => status == null || new[] { "Pending", "In progress", "Completed" }
                .Contains(status))
            .WithMessage("Status must be 'Pending', 'In progress', or 'Completed'.");

        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Limit)
            .GreaterThan(0)
            .WithMessage("Limit must be greater than 0.");
    }
}