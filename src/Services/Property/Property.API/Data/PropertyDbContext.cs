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
        public DbSet<City> Cities { get; set; }
        public DbSet<Metro> Metros { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PropertyUser> Users { get; set; }
        public DbSet<PropertyRole> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Home>().HasOne(x => x.City).WithMany(x => x.Homes).HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Home>().HasMany(x => x.Images).WithOne(x => x.Home)
                .HasForeignKey(x => x.HomeId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Home>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Home>().HasKey(x => x.Id);

            modelBuilder.Entity<Home>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Home>().HasOne(x => x.Region).WithMany(x => x.Homes).HasForeignKey(x => x.RegionId)
                .HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Home>().HasOne(x => x.Metro).WithMany(x => x.Homes).HasForeignKey(x => x.MetroId)
                .HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Region>().HasOne(x => x.City).WithMany(x => x.Regions).HasForeignKey(x => x.CityId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Region>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Metro>().HasOne(x => x.Region).WithMany(x => x.Metros).HasForeignKey(x => x.RegionId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Metro>()
                .Property(x => x.Id)
                .UseIdentityColumn();


            modelBuilder.Entity<Home>().HasOne(x => x.User).WithMany(x => x.Homes).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PropertyUser>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<PropertyRole>().HasOne(x => x.User).WithMany(x => x.Roles).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            base.OnModelCreating(modelBuilder);
        }
    }
}
