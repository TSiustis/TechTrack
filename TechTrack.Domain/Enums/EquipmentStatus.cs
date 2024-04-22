using System.ComponentModel;

namespace TechTrack.Domain.Enums
{
    public enum EquipmentStatus
    {
        [Description("Available")]
        Available,
        [Description("Assigned")]
        Assigned,
        [Description("UnderMaintenance")]
        UnderMaintenance,
        [Description("Retired")]
        Retired
    }
}
