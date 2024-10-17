﻿using JobHunt.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobHunt.Infrastructure.EntityConfiguration;

public class ExperienceEntityConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("experiences");
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Position).HasColumnName("position").IsRequired();
        builder.Property(p => p.CompanyName).HasColumnName("company_name").IsRequired();
        builder.Property(p => p.Responsibility).HasColumnName("responsibility").IsRequired();
        builder.Property(p => p.Location).HasColumnName("location").IsRequired();
        builder.Property(p => p.WorkFrom).HasColumnName("work_from").IsRequired();
        builder.Property(p => p.WorkTo).HasColumnName("work_to").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("user_id");
        
        
    }
}