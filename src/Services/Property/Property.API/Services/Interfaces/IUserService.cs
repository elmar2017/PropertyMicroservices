using Property.API.Dtos.Location;
using Property.API.Dtos.User;
using Property.API.Entities;

namespace Property.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<PropertyUser?> GetAsync(string email);
        Task<PropertyUser> AddAsync(CreateUserDto createUserDto);
    }
}
