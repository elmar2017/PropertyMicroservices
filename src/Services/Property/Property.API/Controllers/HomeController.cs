using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Property.API.Data;
using Property.API.Dtos.Home;
using Property.API.Dtos.Location;
using Property.API.Dtos.User;
using Property.API.Entities;
using Property.API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Property.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILocationService locationService;
        private readonly IPropertySearchService propertySearchService;
        public static IWebHostEnvironment _environment;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(ILocationService locationService, IPropertySearchService propertySearchService, IUserService userService, IMapper mapper)
        {
            this.locationService = locationService;
            this.propertySearchService = propertySearchService;
            _userService = userService;
            _mapper = mapper;
        }


        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<CityDto> Get()
        {
            return locationService.GetCities();
        }

        [HttpGet("getProperties")]
        public IEnumerable<HomeDto> GetProperties([FromQuery]PropertySearchDto propertySearchDto)
        {
            return propertySearchService.SearchProperties(propertySearchDto);
        }

        [HttpGet("getPropertyImage/{propertyId}")]
        public async Task<IActionResult>GetPropertyImage(int propertyId)
        {
            var file = await propertySearchService.GetPropertyImageById(propertyId);

            return File(file.FileBytes, file.ContentType); // Adjust the content type as needed
        }


        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PropertyCreateDto propertyUploadDto)
        {
            var createUserDto = _mapper.Map<CreateUserDto>(propertyUploadDto);
            var user = await _userService.AddAsync(createUserDto);
            await propertySearchService.CreatePropertyAsync(user, propertyUploadDto);
           return Ok();
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
