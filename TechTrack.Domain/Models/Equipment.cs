using TechTrack.Domain.Common;
using TechTrack.Domain.Common.Interfaces;
using TechTrack.Domain.Enums;

namespace TechTrack.Domain.Models
{
    public class  Equipment : IHasDomainEvent
    {
        public Guid Id { get; set; }     
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime? AssignmentDate { get; set; }   
        public DateTime? ReturnDate { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public User? AssignedTo { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
