﻿namespace JobHunt.Application.DTO;

public class AddressDTO
{
    public Guid Id { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
}