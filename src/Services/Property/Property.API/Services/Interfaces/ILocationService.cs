using Property.API.Dtos.Location;
using Property.API.Entities;

namespace Property.API.Services.Interfaces
{
    public interface ILocationService
    {
        ICollection<CityDto> GetCities();
    }
}
