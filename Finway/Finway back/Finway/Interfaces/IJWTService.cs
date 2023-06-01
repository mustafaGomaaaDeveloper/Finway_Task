using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Finway.Interfaces
{
    public interface IJWTService
    {
         Task<JwtSecurityToken> CreateJwtToken(IdentityUser user);
    }
}
