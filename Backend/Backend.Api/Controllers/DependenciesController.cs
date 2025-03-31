using Backend.Contracts.Dependencies;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/assignments/{assignmentId}/dependencies")]
public class DependenciesController : ApiController
{
    [HttpGet]
    public IActionResult ListDependencies(Guid taskId, [FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public IActionResult CreateDependency(Guid assignmentId, CreateDependencyRequest request)
    {
        return Ok(new { AssignmentId = assignmentId, request });
    }

    [HttpDelete("{dependencyId}")]
    public IActionResult DeleteDependency(Guid assignmentId, Guid dependencyId)
    {
        return Ok(new { AssignmentId = assignmentId, DependencyId = dependencyId });
    }
}