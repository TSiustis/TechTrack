using System.ComponentModel.DataAnnotations;
using TechTrack.Domain.Enums;

namespace TechTrack.Common.Dtos.Equipments
{
    public class EquipmentForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type must be between 1 and 50 characters", MinimumLength = 1)]
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
