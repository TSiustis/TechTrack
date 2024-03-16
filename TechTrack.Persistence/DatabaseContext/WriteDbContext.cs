using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Models;
using TechTrack.Persistence.Configurations;

namespace TechTrack.Persistence.DatabaseContext
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("write");
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        }
    }
}
