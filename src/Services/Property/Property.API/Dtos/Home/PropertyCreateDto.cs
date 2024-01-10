namespace Property.API.Dtos.Home
{
    public class PropertyCreateDto
    {
        public string Title { get; set; }
        public bool IsSale { get; set; }
        public string Addresss { get; set; }
        public int BuiltYear { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool HasDocument { get; set; }
        public bool IsOnMortgage { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public int CityId { get; set; }
        public int MetroId { get; set; }
        public int RegionId { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public bool IsByOwner { get; set; }
        public List<IFormFile> Images { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
