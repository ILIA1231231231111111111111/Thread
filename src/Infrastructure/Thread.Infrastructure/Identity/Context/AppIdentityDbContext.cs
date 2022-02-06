using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Thread.Infrastructure.Identity.Context;

public class AppIdentityDbContext : IdentityUserContext<ApplicationUser, Guid>
{
    public AppIdentityDbContext(DbContextOptions options) : base(options)
    {
    }
}