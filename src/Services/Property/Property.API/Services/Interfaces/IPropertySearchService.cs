using Property.API.Dtos.Home;
using Property.API.Entities;
using Property.API.Models;

namespace Property.API.Services.Interfaces
{
    public interface IPropertySearchService
    {
        List<HomeDto> SearchProperties(PropertySearchDto propertySearchDto);
        Task<Home> CreatePropertyAsync(PropertyUser user, PropertyCreateDto propertyCreateDto);
        Task<Home> GetById(int propertyId);
        Task<CustomFile> GetPropertyImageById(int propertyId);
    }
}
