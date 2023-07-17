namespace Property.API.Entities
{
    public class LocationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
