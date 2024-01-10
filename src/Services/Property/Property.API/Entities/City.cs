namespace Property.API.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Home> Homes { get; set; }
        public ICollection<Region> Regions { get; set; }

    }
}
