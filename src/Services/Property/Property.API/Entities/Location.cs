namespace Property.API.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationType LocationType { get; set; }
        public int LocationTypeId { get; set; }
        public ICollection<Home> Homes { get; set; }

    }
}
