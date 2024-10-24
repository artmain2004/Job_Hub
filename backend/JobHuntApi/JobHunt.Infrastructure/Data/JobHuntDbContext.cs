﻿using System.Reflection;
using JobHunt.Domain.Models;
using JobHunt.Infrastructure.Identity;
using JobHunt.Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Infrastructure.Data;

public class JobHuntDbContext : IdentityDbContext<User>
{

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<Job> Jobs { get; set; }

    public DbSet<University> Universities { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host = localhost; Port=5432; Database=JobHuntDb; Username=postgres; Password=password")
            .AddInterceptors(new AuditableInterceptor());
                
          


    }
    
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
       
        builder.Entity<IdentityUserLogin<string>>().HasNoKey();
        builder.Entity<IdentityUserToken<string>>().HasNoKey();
        builder.Entity<IdentityUserRole<string>>().HasNoKey();
    }
}