﻿namespace JobHunt.Application.Request;

public class UserRegisterRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}