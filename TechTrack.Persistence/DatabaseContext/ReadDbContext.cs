using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Models;
using TechTrack.Persistence.Configurations;

namespace TechTrack.Persistence.DatabaseContext
{
    public class ReadDbContext : DbContext
    {
        public ReadDbContext()
        {

        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
            
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("read");
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }   
    }
}
