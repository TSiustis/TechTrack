using Microsoft.EntityFrameworkCore;
using TechTrack.Application.Common.Interfaces;
using TechTrack.Domain.Common;
using TechTrack.Domain.Common.Interfaces;
using TechTrack.Domain.Models;
using TechTrack.Persistence.Configurations;

namespace TechTrack.Persistence.DatabaseContext
{
    public class WriteDbContext : DbContext
    {
        private readonly IDomainEventService _domainEventService;

        public WriteDbContext(DbContextOptions<WriteDbContext> options, IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("write");
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(cancellationToken);

            return result;
        }

        private async Task DispatchEvents(CancellationToken cancellationToken)
            {
            var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                .SelectMany(entity => entity.Entity.DomainEvents)
                .ToArray();

            foreach (var domainEvent in domainEventEntities)
            {
                await _domainEventService.Raise(domainEvent, cancellationToken);
            }
        }
    }
}
