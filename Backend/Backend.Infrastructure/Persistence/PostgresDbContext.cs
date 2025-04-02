using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.DependencyModel;
using Backend.Domain.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    public DbSet<Assignment> Assignments { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Dependency> Dependencies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}