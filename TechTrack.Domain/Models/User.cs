namespace TechTrack.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public ICollection<Equipment> AssignedEquipments { get; set; } = new List<Equipment>();
    }
}
