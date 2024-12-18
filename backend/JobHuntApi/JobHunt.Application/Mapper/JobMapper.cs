﻿using System.Text.Json;
using JobHunt.Application.DTO;
using JobHunt.Application.Request.Job;
using JobHunt.Application.Response.Job;
using JobHunt.Domain.Models;

namespace JobHunt.Application.Mapper;

public static class JobMapper
{
    public static List<JobsResponse>  ToJobsResponse(this List<Job> jobs){
    {
        var jobsResponse = jobs 
            .Select(j => new JobsResponse()
            {
                    Id = j.Id,
                    Title = j.Title,
                    CompanyName = j.CompanyName,
                    City = j.Address!.City,
                    OperationMode = j.OperationMode,
                    CompanyLogo = j.Image?.ImageUrl,
                    Salary = j.Salary,
                    CreatedAt = j.CreatedAt,
                    
            })
            .ToList();
        
        return jobsResponse;
    }}

    public static SingleJobResponse ToSingleJobResponse(this Job job)
    {
        var singleJobResponse = new SingleJobResponse()
        {
            Id = job.Id,
            Title = job.Title,
            CompanyName = job.CompanyName,
            OperationMode = job.OperationMode,
            ContractType = job.ContractType,
            JobLevel = job.JobLevel,
            Responsibilities = JsonSerializer.Deserialize<List<string>>(job.Responsibilities) ,
            Requirements = JsonSerializer.Deserialize<List<string>>(job.Requirements),
            AboutCompany = job.AboutCompany,
            CreatedBy = job.CreatedBy,
            Salary = job.Salary,
            Type = job.Type,
            Technology = job.Technology,
            Address = new AddressDTO()
            {
                Id = job.Address!.Id,
                Country = job.Address.Country,
                City = job.Address.City,
                Street = job.Address.Street,
            },
            Image = new ImageDTO()
            {
                Id = job.Image!.Id,
                ImageUrl = job.Image!.ImageUrl,
            }
        };
        
        return singleJobResponse;
    }

    public static Job ToJobModelCreate( CreateJobRequest jobRequest, Guid addressId, Guid imageId)
    {
        return new Job()
        {
            Id = Guid.NewGuid(),
            Title = jobRequest.Title,
            CompanyName = jobRequest.CompanyName,
            OperationMode = jobRequest.OperationMode,
            ContractType = jobRequest.ContractType,
            JobLevel = jobRequest.JobLevel,
            Responsibilities = JsonSerializer.Serialize(jobRequest.Responsibilities),
            Requirements = JsonSerializer.Serialize(jobRequest.Requirements),
            AddressId = addressId,
            Type = jobRequest.Type,
            Technology = jobRequest.Technology,
            CreatedBy = jobRequest.CreatedBy,
            ImageId = imageId,
            AboutCompany = jobRequest.AboutCompany,
            Salary = jobRequest.Salary
        };
    }
    
    public static Job ToJobModelUpdate(UpdateJobRequest jobRequest)
    {
        return new Job()
        {
            Title = jobRequest.Title,
            CompanyName = jobRequest.CompanyName,
            OperationMode = jobRequest.OperationMode,
            ContractType = jobRequest.ContractType,
            JobLevel = jobRequest.JobLevel,
            Responsibilities = JsonSerializer.Serialize(jobRequest.Responsibilities),
            Requirements = JsonSerializer.Serialize(jobRequest.Requirements),
            Type = jobRequest.Type,
            Technology = jobRequest.Technology,
            CreatedBy = jobRequest.CreatedBy!,
            AboutCompany = jobRequest.AboutCompany,
            Salary = jobRequest.Salary,
            
        };
    }
}