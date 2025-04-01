using Backend.Application.Services.Dependencies.Commands.CreateDependency;
using Backend.Application.Services.Dependencies.Commands.DeleteDependency;
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
    public IActionResult ListDependencies(Guid taskId, [FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public async Task<IActionResult> CreateDependency(Guid assignmentId, CreateDependencyRequest request)
    {
        var command = _mapper.Map<CreateDependencyCommand>((assignmentId, request));

        var result = await _mediator.Send(command);

        return result.Match(
            dependency => Created(HttpContext.Request.Path, _mapper.Map<DependencyResponse>(dependency)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{dependencyId}")]
    public async Task<IActionResult> DeleteDependency(Guid assignmentId, Guid dependencyId)
    {
        var command = _mapper.Map<DeleteDependencyCommand>((assignmentId, dependencyId));

        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
}