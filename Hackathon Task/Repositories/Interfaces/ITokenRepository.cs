using Microsoft.AspNetCore.Identity;

namespace Hackathon_Task.Repositories.Interfaces;

public interface ITokenRepository
{
    string CreateJwtToken(IdentityUser user);
}
