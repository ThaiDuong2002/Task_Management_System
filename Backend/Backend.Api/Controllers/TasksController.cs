using Backend.Contracts.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/tasks")]
public class TasksController : ApiController
{
    [HttpGet]
    public IActionResult ListTasks([FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<StringComparer>());
    }

    [HttpPost]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(UpdateTaskRequest request, Guid id)
    {
        return Ok(request);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(Guid id)
    {
        return Ok(id);
    }
}