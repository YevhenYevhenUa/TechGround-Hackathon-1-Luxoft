using Hackathon_Task.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hackathon_Task.Repositories.Implementation;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration configuration;

    public TokenRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string CreateJwtToken(IdentityUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
