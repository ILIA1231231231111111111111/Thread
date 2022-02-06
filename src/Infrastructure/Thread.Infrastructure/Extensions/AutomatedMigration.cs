using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Thread.Infrastructure.Identity.Context;

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
}