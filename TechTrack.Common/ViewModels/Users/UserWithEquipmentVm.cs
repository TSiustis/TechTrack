using TechTrack.Common.ViewModel.Equipments;

namespace TechTrack.Common.ViewModel.Users
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