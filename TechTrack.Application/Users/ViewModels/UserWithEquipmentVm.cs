using TechTrack.Application.Equipments.ViewModels;

namespace TechTrack.Application.Users.ViewModels
{
    public class UserWithEquipmentsVm
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public List<EquipmentOutputVm> Equipments { get; set; } = new List<EquipmentOutputVm>();
    }
}