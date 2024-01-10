namespace Property.API.Entities
{
    public class Home
    {
        public int Id { get; set; }
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
        public City City { get; set; }
        public int CityId { get; set; }
        public Metro Metro { get; set; }
        public int MetroId { get; set; }
        public Region Region{ get; set; }
        public int RegionId { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public bool IsByOwner { get; set; }
        public bool IsAvailable { get; set; }
        public List<HomeImage> Images { get; set; }
        public PropertyUser User { get; set; }
        public long UserId { get; set; }

        public Home()
        {
            Images = new List<HomeImage>();
        }


    }
}
