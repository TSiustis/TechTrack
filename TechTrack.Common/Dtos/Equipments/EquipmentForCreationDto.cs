using TechTrack.Domain.Enums;

namespace TechTrack.Common.Dtos.Equipments
{
    public class EquipmentForCreationDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? AssignedToUserId { get; set; }
    }
}
