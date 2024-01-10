using Property.API.Enums;

namespace Property.API.Dtos.Home
{
    public class PropertySearchDto
    {
        public GivenType GivenType { get; set; }
        public int BuiltYear { get; set; }
        public ConditionType Condition { get; set; }
        public DocumentType Document { get; set; }
        public MortgageType Mortgage { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinArea { get; set; }
        public int MaxArea { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public int RoomCount { get; set; }
        public int CityId { get; set; }
        public List<int> RegionIds { get; set; }
        public List<int> MetroIds { get; set; }
        public OwnerType OwnerType { get; set; }

        public PropertySearchDto()
        {
            RegionIds = new List<int>();
            MetroIds = new List<int>();
        }

    }
}
