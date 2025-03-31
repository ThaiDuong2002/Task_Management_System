using Backend.Contracts.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/notifications")]
public class NotificationController : ApiController
{
    [HttpGet]
    public IActionResult ListNotifications([FromQuery] int page = 1, int limit = 10)
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public IActionResult CreateNotification(CreateNotificationRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id}")]
    public IActionResult GetNotification(Guid id)
    {
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNotification(Guid id)
    {
        return Ok(id);
    }
}