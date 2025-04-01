using Backend.Application.Assignments.Commands.CreateAssignment;
using Backend.Application.Assignments.Commands.UpdateAssignment;
using Backend.Contracts.Assignments;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/assignments")]
public class AssignmentsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AssignmentsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetAssignments([FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<StringComparer>());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssignment(CreateAssignmentRequest request)
    {
        var command = _mapper.Map<CreateAssignmentCommand>(request);

        var result = await _mediator.Send(command);

        return result.Match(
            assignment => Created(HttpContext.Request.Path, _mapper.Map<AssignmentResponse>(assignment)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetAssignment(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssignment(UpdateAssignmentRequest request, Guid id)
    {
        var command = _mapper.Map<UpdateAssignmentCommand>((request, id));

        var result = await _mediator.Send(command);

        return result.Match(
            assignment => Ok(_mapper.Map<ModifyAssignmentResponse>(assignment)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAssignment(Guid id)
    {
        return Ok(id);
    }
}