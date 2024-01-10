using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Property.API.Data;
using Property.API.Dtos.Home;
using Property.API.Entities;
using Property.API.Enums;
using Property.API.Models;
using Property.API.Services.Interfaces;

namespace Property.API.Services.Concrete
{
    public class PropertySearchService : IPropertySearchService
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private const string HomeImagesFolder = "HomeImages";

        public PropertySearchService(PropertyDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public List<HomeDto> SearchProperties(PropertySearchDto psd)
        {
            var isNew = psd.Condition == ConditionType.IsNew;
            var allCondition = psd.Condition == ConditionType.All;

            var hasDocument = psd.Document == DocumentType.HasDocument;
            var allDocuments = psd.Document == DocumentType.All;

            var isOnMortgage = psd.Mortgage == MortgageType.OnMortgage;
            var allMortgage = psd.Mortgage == MortgageType.All;


            var isSale = psd.GivenType == GivenType.IsSale;
            var allGivenTypes = psd.GivenType == GivenType.All;

            var isOwner = psd.OwnerType == OwnerType.IsOwner;
            var AllOwnerTypes = psd.OwnerType == OwnerType.All;


            var homes = _context.Homes.Include(x => x.Images).Include(x => x.City)
                .Include(x => x.Region).Include(x => x.Metro).Where(x =>
                (psd.BuiltYear == 0 || x.BuiltYear >= psd.BuiltYear) &&
                (allGivenTypes || x.IsSale == isSale) &&
                (allCondition || x.IsNew == isNew) &&
                (allDocuments || x.HasDocument == hasDocument) &&
                (allMortgage || x.IsOnMortgage == isOnMortgage) &&
                ((psd.MinPrice == 0 || x.Price >= psd.MinPrice) && (psd.MaxPrice == 0 || x.Price <= psd.MaxPrice)) &&
                ((psd.MinArea == 0 || x.Area >= psd.MinArea) && (psd.MaxArea == 0 || x.Area <= psd.MaxArea)) &&
                ((psd.MinFloor == 0 || x.Floor >= psd.MinFloor) && (psd.MaxFloor == 0 || x.Floor <= psd.MaxFloor)) &&
                (psd.RoomCount == 0 || x.RoomCount == psd.RoomCount) &&
                (psd.CityId == 0 || x.CityId == psd.CityId) &&
                (psd.RegionIds.Count == 0 || psd.RegionIds.Contains(x.RegionId)) &&
                (psd.MetroIds.Count == 0 || psd.MetroIds.Contains(x.MetroId))
            ).ToList();

            var homeDtos = _mapper.Map<List<HomeDto>>(homes);
            return homeDtos;
        }

        public async Task<Home> CreatePropertyAsync(PropertyUser user, PropertyCreateDto propertyCreateDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
                {
                    _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                // Create a unique folder name using GUID.
                var folderPath = Path.Combine(_environment.WebRootPath, HomeImagesFolder);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var home = _mapper.Map<Home>(propertyCreateDto);

                for (var i = 0; i < propertyCreateDto.Images.Count; i++)
                {
                    var file = propertyCreateDto.Images.ElementAt(i);
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(folderPath, fileName);
                        await using var stream = new FileStream(filePath, FileMode.Create);
                        await file.CopyToAsync(stream);
                        home.Images.Add(new HomeImage { ImageName = fileName, ContentType = file.ContentType, IsMain = i == 0 });
                    }
                }

                user.Homes.Add(home);
                await _context.SaveChangesAsync();
                return home;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<Home> GetById(int propertyId)
        {
            var home = await _context.Homes.FirstOrDefaultAsync(h => h.Id == propertyId);
            return home;
        }

        public async Task<CustomFile> GetPropertyImageById(int propertyId)
        {
            try
            {
                var home = await _context.Homes.Include(x => x.Images).Where(x => x.Id == propertyId).SingleAsync();
                var mainImage = home.Images.Single(x => x.IsMain);
                var folderPath = Path.Combine(_environment.WebRootPath, HomeImagesFolder, mainImage.ImageName);
                var imageBytes = await File.ReadAllBytesAsync(folderPath);

                return new CustomFile
                {
                    FileBytes = imageBytes,
                    ContentType = mainImage.ContentType
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
