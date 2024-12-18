﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobHunt.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobHunt.Application.Service;

public class TokenService :  ITokenService
{
    
    private readonly JwtOptions _jwtOptions;

    public TokenService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateToken(string email, IList<string> roles)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var tokenHandler = new JwtSecurityTokenHandler();

        
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, email),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


        var token = new JwtSecurityToken(
           
            claims: claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            expires: DateTime.Now.AddDays(5)
        );
        
        return tokenHandler.WriteToken(token) ;
    }
}