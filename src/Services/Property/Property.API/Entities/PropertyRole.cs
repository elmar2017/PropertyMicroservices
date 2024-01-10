namespace Property.API.Entities
{
    public class PropertyRole
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public  PropertyUser User { get; set; }
        public string Name { get; set; }

    }
}
