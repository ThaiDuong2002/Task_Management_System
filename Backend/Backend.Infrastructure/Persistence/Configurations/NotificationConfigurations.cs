using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.NotificationModel;
using Backend.Domain.Models.NotificationModel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        ConfigureNotificationsTable(builder);
    }

    private static void ConfigureNotificationsTable(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.HasKey(n => n.Id);

        builder
            .Property(n => n.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => NotificationId.Create(value)
            )
            .IsRequired();

        builder
            .Property(n => n.UserId)
            .IsRequired();

        builder
            .Property(n => n.AssignmentId)
            .HasConversion(
                id => id.Value,
                value => AssignmentId.Create(value)
            )
            .IsRequired();

        builder
            .Property(n => n.Type)
            .HasConversion(
                type => type.Value,
                value => NotificationType.Create(value)
            )
            .IsRequired();

        builder
            .Property(n => n.Message)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(n => n.IsRead)
            .IsRequired();

        builder
            .Property(n => n.ScheduledTime)
            .IsRequired();

        builder
            .Property(n => n.CreatedAt)
            .IsRequired();

        builder
            .Property(n => n.UpdatedAt)
            .IsRequired();
    }
}