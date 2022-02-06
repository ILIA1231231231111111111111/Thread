using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

#nullable enable

namespace Thread.Infrastructure.Identity.Context;

public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
{
    public AppIdentityDbContext CreateDbContext(string[] args)
    {
        var connection = "Server=(localdb)\\mssqllocaldb;Database=ThreadIdentityDb;Trusted_Connection=True;";
        
        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
        optionsBuilder.UseSqlServer(connection);

        return new AppIdentityDbContext(optionsBuilder.Options);
    }
}