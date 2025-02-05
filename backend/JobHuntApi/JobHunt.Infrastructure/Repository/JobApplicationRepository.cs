﻿
using JobHunt.Domain.Interface.Repository;
using JobHunt.Domain.Models;
using JobHunt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Infrastructure.Repository;

public class JobApplicationRepository : IJobApplicationRepository
{
    private readonly JobHuntDbContext _context;

    public JobApplicationRepository(JobHuntDbContext context)
    {
        _context = context;
    }

    public async Task CreateJobApplicationsAsync(JobApplication jobApplication)
    {
        await _context.JobApplications.AddAsync(jobApplication);
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<JobApplication>> GetAllJobsApplicationByJobId(Guid jobId)
    {
        return await _context.JobApplications
            .Where(j => j.JobId == jobId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<JobApplication?> GetJobApplicationById(Guid jobApplicationId)
    {
        return await _context.JobApplications.FirstOrDefaultAsync(j => j.Id == jobApplicationId);
    }

    public async Task<List<JobApplication>> GetAllJobsApplicationByCreatedById(string createdById)
    {
        return await _context.JobApplications
            .Where(j => j.CreatedBy == createdById)
            .AsNoTracking()
            .Include(j => j.Job)
            .ThenInclude(j => j!.Address)
            .Include(j => j.Job)
            .ThenInclude(j => j!.Image)
            .ToListAsync();
    }

    public async Task UpdateJobApplicationStatusAsync(Guid jobApplicationId, string newStatus)
    {
        await _context.JobApplications
            .Where(j => j.Id == jobApplicationId)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Status, newStatus)
            );
    }
}