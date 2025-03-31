using Backend.Contracts.Assignments;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/assignments")]
public class AssignmentsController : ApiController
{
    [HttpGet]
    public IActionResult GetAssignments([FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<StringComparer>());
    }

    [HttpPost]
    public IActionResult CreateAssignment(CreateAssignmentRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id}")]
    public IActionResult GetAssignment(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAssignment(UpdateAssignmentRequest request, Guid id)
    {
        return Ok(request);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAssignment(Guid id)
    {
        return Ok(id);
    }
}