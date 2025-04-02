using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.UserModel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        ConfigureAssignmentsTable(builder);
    }

    private static void ConfigureAssignmentsTable(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("Assignments");

        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AssignmentId.Create(value)
            )
            .IsRequired();

        builder
            .Property(a => a.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            )
            .IsRequired();

        builder
            .Property(a => a.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(a => a.Description)
            .HasMaxLength(1000);

        builder
            .Property(a => a.Priority)
            .HasConversion(
                p => p.Value,
                value => Priority.Create(value)
            )
            .IsRequired();

        builder.Property(a => a.Status)
            .HasConversion(
                s => s.Value,
                value => Status.Create(value)
            )
            .IsRequired();

        builder.Property(a => a.DueDate)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder
            .HasMany(a => a.Dependencies)
            .WithOne()
            .HasForeignKey(d => d.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}