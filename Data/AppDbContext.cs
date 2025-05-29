using Microsoft.EntityFrameworkCore;
using TravelGuide.Models;

namespace TravelGuide.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }

        // Метод должен быть внутри класса!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attraction>()
                .Property(a => a.EntranceFee)
                .HasPrecision(18, 2);
        }
    }
}