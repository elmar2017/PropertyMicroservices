namespace Property.API.Entities
{
    public class HomeImage
    {
        public long Id { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
        public string ImageName{ get; set; }
        public string ContentType { get; set; }
        public bool IsMain { get; set; }
    }
}
