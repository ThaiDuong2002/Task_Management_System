using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.NotificationModel;
using Backend.Domain.Models.NotificationModel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly PostgresDbContext _dbContext;

    public NotificationRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Notification>> GetAll(Guid userId, int? page, int? limit)
    {
        var notifications = _dbContext.Notifications.AsQueryable();

        if (page.HasValue && limit.HasValue)
            notifications = notifications.Skip((page.Value - 1) * limit.Value).Take(limit.Value);

        return await notifications.ToListAsync();
    }

    public async Task<int> Create(Notification notification)
    {
        _dbContext.Notifications.Add(notification);
        return await _dbContext.SaveChangesAsync();
    }

    public Task<int> Delete(Notification notification)
    {
        _dbContext.Notifications.Remove(notification);
        return _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateReadStatus(Guid notificationId)
    {
        var notification = _dbContext.Notifications.FirstOrDefault(n => n.Id.Value == notificationId);
        notification!.UpdateReadStatus(true);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> ReadAll(Guid userId)
    {
        var notifications = _dbContext.Notifications.Where(n => n.UserId == userId).ToList();
        notifications.ForEach(n => n.UpdateReadStatus(true));

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CreateUpcomingNotifications()
    {
        var upcomingAssignments = _dbContext.Assignments
            .Where(a => a.DueDate > DateTime.UtcNow && a.Status.Value != "Completed").ToList();

        foreach (var assignment in upcomingAssignments)
        {
            var notification = Notification.Create(
                assignment.UserId,
                assignment.Id,
                NotificationType.Create("Upcoming"),
                $"Assignment {assignment.Title} is due on {assignment.DueDate}",
                false,
                assignment.DueDate,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            await _dbContext.Notifications.AddAsync(notification);
        }

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CreateOverdueNotifications()
    {
        var overdueAssignments = _dbContext.Assignments.Where(a => a.DueDate < DateTime.UtcNow).ToList();

        foreach (var assignment in overdueAssignments)
        {
            var notification = Notification.Create(
                assignment.UserId,
                assignment.Id,
                NotificationType.Create("Overdue"),
                $"Assignment {assignment.Title} is overdue",
                false,
                assignment.DueDate,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            await _dbContext.Notifications.AddAsync(notification);
        }

        return await _dbContext.SaveChangesAsync();
    }
}