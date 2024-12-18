﻿using JobHunt.Domain.Models;

namespace JobHunt.Domain.Interface.Repository;

public interface IJobRepository
{
    Task<List<Job>> GetAllJobsAsync();
    Task<Job?> GetJobByIdAsync(Guid jobId);
    Task CreateJobAsync(Job job);
    Task<bool> UpdateJobAsync(Job job, Guid jobId);
    Task<bool> DeleteJobAsync(Guid jobId);
    Task<List<Job>> GetAllJobsByFilterAsync(string? type, string? technology, string? level);
    Task<List<Job>> GetAllJobsByTitleAsync(string title);
    Task<List<Job>> GetAllJobsByCreatedByIdAsync(string createdById);
}