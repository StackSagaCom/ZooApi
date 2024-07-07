using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ZooContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FoodSupply> FoodSupplies { get; set; }
        public double FoodSupply { get; set; }

        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasDiscriminator<string>("AnimalType")
                .HasValue<Carnivore>("Carnivore")
                .HasValue<Herbivore>("Herbivore")
                .HasValue<Giraffe>("Giraffe");

        }

    }
}
