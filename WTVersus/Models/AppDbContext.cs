using Microsoft.EntityFrameworkCore;

namespace WTVersus.Models
{
    /// <summary>Application database context</summary>
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {}

        public DbSet<Plane> Planes { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Heli> Helis { get; set; }

    }
}
