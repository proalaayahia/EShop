namespace EShop.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    public AggregateRoot(Guid id) : base(id)
    {

    }
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
