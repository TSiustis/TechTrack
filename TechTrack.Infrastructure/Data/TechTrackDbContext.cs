using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Configurations;

namespace TechTrack.Infrastructure.Data
{
    public class TechTrackDbContext : DbContext
    {
        public TechTrackDbContext(DbContextOptions<TechTrackDbContext> options) : base(options)
        {
            
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        }   
    }
}
