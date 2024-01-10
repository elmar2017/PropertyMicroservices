namespace Property.API.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Home> Homes { get; set; }
        public ICollection<Metro> Metros { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }

    }
}
