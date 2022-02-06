using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Thread.Infrastructure.Persistence.Context;

public class ThreadDbContextFactory : IDesignTimeDbContextFactory<ThreadDbContext>
{
    public ThreadDbContext CreateDbContext(string[] args)
    {
        var connection = "Server=(localdb)\\mssqllocaldb;Database=ThreadDb;Trusted_Connection=True;";

        var optionsBuilder = new DbContextOptionsBuilder<ThreadDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new ThreadDbContext(optionsBuilder.Options);
    }
}