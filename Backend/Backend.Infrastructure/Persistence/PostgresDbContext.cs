using Backend.Domain.Models.AssignmentModel;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    public DbSet<Assignment> Assignments { get; set; } = null!;
}