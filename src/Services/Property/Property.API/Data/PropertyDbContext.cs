using Microsoft.EntityFrameworkCore;
using Property.API.Entities;
namespace Property.API.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options)
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Home>().HasOne(x => x.Location).WithMany(x => x.Homes).HasForeignKey(x => x.LocationId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Location>().HasOne(x => x.LocationType).WithMany(x => x.Locations).HasForeignKey(x => x.LocationTypeId)
                .HasPrincipalKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
