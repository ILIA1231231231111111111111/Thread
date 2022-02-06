using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Thread.Infrastructure.Identity.Context;
using Thread.Infrastructure.Persistence.Context;

#nullable enable

namespace Thread.Infrastructure.Extensions;

public static class AutomatedMigration
{
    public static async Task MsSqlIdentityDatabaseMigrateAsync(this IServiceProvider services)
    {
        var context = services.GetRequiredService<AppIdentityDbContext>();

        if (context.Database.IsSqlServer())
        {
            await context.Database.MigrateAsync();
        }
    }
    
    public static async Task MsSqlThreadDatabaseMigrateAsync(this IServiceProvider services)
    {
        var context = services.GetRequiredService<ThreadDbContext>();

        if (context.Database.IsSqlServer())
        {
            await context.Database.MigrateAsync();
        }
    }
}