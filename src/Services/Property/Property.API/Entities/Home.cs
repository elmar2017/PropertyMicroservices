namespace Property.API.Entities
{
    public class Home
    {
        public string Id { get; set; }
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
        public string Image { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string ContactPerson { get; set; }
        public bool IsByOwner { get; set; }
        public bool IsAvailable { get; set; }


    }
}
