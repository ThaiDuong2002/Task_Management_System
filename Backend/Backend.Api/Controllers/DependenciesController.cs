using Backend.Application.Services.Dependencies.Commands.CreateDependency;
using Backend.Application.Services.Dependencies.Commands.DeleteDependency;
using Backend.Application.Services.Dependencies.Queries.GetDependencies;
using Backend.Contracts.Dependencies;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/assignments/{assignmentId}/dependencies")]
public class DependenciesController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public DependenciesController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListDependencies(Guid assignmentId, [FromQuery] int? page, int? limit)
    {
        var result = await _mediator.Send(new GetDependenciesQuery(assignmentId, page, limit));

        return result.Match(
            dependencies => Ok(_mapper.Map<List<DependencyResponse>>(dependencies)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateDependency(Guid assignmentId, CreateDependencyRequest request)
    {
        var result = await _mediator.Send(new CreateDependencyCommand(
            assignmentId,
            request.DependOnAssignmentId
        ));

        return result.Match(
            dependency => Created(HttpContext.Request.Path, _mapper.Map<DependencyResponse>(dependency)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{dependencyId}")]
    public async Task<IActionResult> DeleteDependency(Guid assignmentId, Guid dependencyId)
    {
        var result = await _mediator.Send(new DeleteDependencyCommand(assignmentId, dependencyId));

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
}