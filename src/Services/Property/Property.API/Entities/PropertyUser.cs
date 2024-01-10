namespace Property.API.Entities
{
    public class PropertyUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public List<PropertyRole> Roles { get; set; }
        public List<Home> Homes { get; set; }

        public PropertyUser()
        {
            Roles = new List<PropertyRole>();
            Homes = new List<Home>();
        }

    }
}
