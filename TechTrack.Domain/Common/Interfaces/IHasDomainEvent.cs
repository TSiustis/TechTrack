namespace TechTrack.Domain.Common.Interfaces
{
    public interface IHasDomainEvent
    {
        List<DomainEvent> DomainEvents { get; set; }
    }
}
