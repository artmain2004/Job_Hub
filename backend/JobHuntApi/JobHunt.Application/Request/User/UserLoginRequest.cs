﻿namespace JobHunt.Application.Request.User;

public class UserLoginRequest
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}