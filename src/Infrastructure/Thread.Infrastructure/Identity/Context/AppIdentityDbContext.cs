﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thread.Core.Entities;

#nullable enable

namespace Thread.Infrastructure.Identity.Context;

public class AppIdentityDbContext : IdentityUserContext<ApplicationUser, Guid>
{
    public AppIdentityDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = "Server=(localdb)\\mssqllocaldb;Database=ThreadIdentityDb;Trusted_Connection=True;";
        
        optionsBuilder.UseSqlServer(connection);
        base.OnConfiguring(optionsBuilder);
    }
}