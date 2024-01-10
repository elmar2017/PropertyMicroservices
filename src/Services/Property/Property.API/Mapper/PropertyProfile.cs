using AutoMapper;
using Property.API.Dtos.Home;
using Property.API.Dtos.Location;
using Property.API.Dtos.User;
using Property.API.Entities;

namespace Property.API.Mapper
{


    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<HomeDto,Home >().ReverseMap().ForMember(x =>x.ImageIds, y =>y.MapFrom(a =>a.Images.Select(b =>b.Id)));
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Metro, MetroDto>().ReverseMap();
            CreateMap<PropertyCreateDto, Home>().ForMember(x => x.Images, y => y.Ignore());

            CreateMap<PropertyCreateDto, CreateUserDto>().ReverseMap();
            CreateMap<CreateUserDto, PropertyUser>().ReverseMap();


        }
    }
}
