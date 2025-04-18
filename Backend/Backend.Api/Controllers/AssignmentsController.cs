using Backend.Application.Services.Assignments.Commands.CreateAssignment;
using Backend.Application.Services.Assignments.Commands.DeleteAssignment;
using Backend.Application.Services.Assignments.Commands.UpdateAssignment;
using Backend.Application.Services.Assignments.Queries.GetAssignment;
using Backend.Application.Services.Assignments.Queries.GetAssignments;
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

    [HttpGet("list/{id}")]
    public async Task<IActionResult> GetAssignments(Guid id, [FromQuery] int? page,
        int? limit, string? status, string? priority, string? options)
    {
        var result =
            await _mediator.Send(new GetAssignmentsQuery(id, page, limit, status, priority, options));

        return result.Match(
            assignments => Ok(_mapper.Map<List<AssignmentResponse>>(assignments)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssignment(Guid id)
    {
        var result = await _mediator.Send(new GetAssignmentQuery(id));

        return result.Match(
            assignment => Ok(_mapper.Map<AssignmentResponse>(assignment)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssignment(CreateAssignmentRequest request)
    {
        var result = await _mediator.Send(new CreateAssignmentCommand(
            request.UserId,
            request.Title,
            request.Description,
            request.Status,
            request.Priority,
            request.DueDate
        ));

        return result.Match(
            assignment => Created(HttpContext.Request.Path, _mapper.Map<AssignmentResponse>(assignment)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssignment(UpdateAssignmentRequest request, Guid id)
    {
        var result = await _mediator.Send(new UpdateAssignmentCommand(
            id,
            request.Title,
            request.Description,
            request.Status,
            request.Priority,
            request.DueDate
        ));

        return result.Match(
            assignment => Ok(_mapper.Map<ModifyAssignmentResponse>(assignment)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(Guid id)
    {
        var result = await _mediator.Send(new DeleteAssignmentCommand(id));

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
}