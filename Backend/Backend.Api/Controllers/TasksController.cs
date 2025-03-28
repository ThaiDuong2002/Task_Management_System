using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("[controller]")]
public class TasksController : ApiController
{
    [HttpGet]
    public IActionResult ListTasks()
    {
        return Ok(Array.Empty<StringComparer>());
    }
}