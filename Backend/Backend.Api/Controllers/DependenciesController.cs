using Backend.Contracts.Dependencies;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/tasks/{taskId}/dependencies")]
public class DependenciesController : ApiController
{
    [HttpGet]
    public IActionResult ListDependencies(Guid taskId, [FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public IActionResult CreateDependency(Guid taskId, CreateDependencyRequest request)
    {
        return Ok(new { TaskId = taskId, request });
    }

    [HttpDelete("{dependencyId}")]
    public IActionResult DeleteDependency(Guid taskId, Guid dependencyId)
    {
        return Ok(new { TaskId = taskId, DependencyId = dependencyId });
    }
}