using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Commands.DeleteDependency;

public class DeleteDependencyCommandHandler : IRequestHandler<DeleteDependencyCommand, ErrorOr<int>>
{
    private readonly IDependencyRepository _dependencyRepository;

    public DeleteDependencyCommandHandler(IDependencyRepository dependencyRepository)
    {
        _dependencyRepository = dependencyRepository;
    }


    public async Task<ErrorOr<int>> Handle(DeleteDependencyCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dependency = Dependency.Create(
            AssignmentId.Create(command.AssignmentId),
            AssignmentId.Create(command.DependOnAssignmentId)
        );

        var result = _dependencyRepository.Delete(dependency);

        if (result == 0) return Errors.Dependency.NotFound;

        return result;
    }
}