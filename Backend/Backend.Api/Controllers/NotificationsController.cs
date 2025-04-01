using Backend.Application.Notifications.Commands.CreateNotification;
using Backend.Application.Notifications.Queries.GetNotifications;
using Backend.Contracts.Notifications;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/notifications")]
public class NotificationsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public NotificationsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListNotifications(Guid id, [FromQuery] int page = 1, int limit = 10)
    {
        var query = _mapper.Map<GetNotificationsQuery>((id, page, limit));

        var result = await _mediator.Send(query);

        return result.Match(
            assignments => Ok(_mapper.Map<List<NotificationResponse>>(assignments)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationRequest request)
    {
        var command = _mapper.Map<CreateNotificationCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            notification => Created(HttpContext.Request.Path, _mapper.Map<NotificationResponse>(notification)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNotification(Guid id)
    {
        return Ok(id);
    }
}