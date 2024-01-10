using AutoMapper;
using Property.API.Data;
using Property.API.Dtos.Location;
using Property.API.Services.Interfaces;

namespace Property.API.Services.NewFolder
{
    public class LocationService : ILocationService
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public LocationService(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<CityDto> GetCities()
        {
            var cities = _context.Cities.ToList();
            return _mapper.Map<ICollection<CityDto>>(cities);
        }

    }
}
