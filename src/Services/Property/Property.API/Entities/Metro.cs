﻿namespace Property.API.Entities
{
    public class Metro
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Home> Homes { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }

    }
}
