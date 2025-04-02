using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel;
using Backend.Domain.Models.DependencyModel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Persistence.Configurations;

public class DependencyConfigurations : IEntityTypeConfiguration<Dependency>
{
    public void Configure(EntityTypeBuilder<Dependency> builder)
    {
        ConfigureDependenciesTable(builder);
    }

    private static void ConfigureDependenciesTable(EntityTypeBuilder<Dependency> builder)
    {
        builder.ToTable("Dependencies");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasConversion(
                id => id.Value,
                value => DependencyId.Create(value)
            )
            .IsRequired();

        builder.Property(d => d.AssignmentId)
            .HasConversion(
                id => id.Value,
                value => AssignmentId.Create(value)
            )
            .IsRequired();

        builder.Property(d => d.DependOnAssignmentId)
            .HasConversion(
                id => id.Value,
                value => AssignmentId.Create(value)
            )
            .IsRequired();

        builder.HasOne(d => d.Assignment)
            .WithMany(a => a.Dependencies)
            .HasForeignKey(d => d.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.DependOnAssignment)
            .WithMany()
            .HasForeignKey(d => d.DependOnAssignmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}