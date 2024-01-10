using System.Security.Claims;

namespace Property.API.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email);
    }
}
