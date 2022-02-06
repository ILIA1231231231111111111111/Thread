using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Thread.Interfaces.Context;

namespace Thread.Infrastructure.Persistence.Context;

public class ThreadDbContext : DbContext, IThreadDbContext
{
    public ThreadDbContext(DbContextOptions<ThreadDbContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = "Server=(localdb)\\mssqllocaldb;Database=ThreadDb;Trusted_Connection=True;";

        optionsBuilder.UseSqlServer(connection);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}