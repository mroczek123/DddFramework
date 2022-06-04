namespace Framework.Domain;

public abstract class AggregateRoot
{
    public AggregateRoot(DateTime? createdAt = null)
    {
        CreatedAt = createdAt != null ? (DateTime) createdAt : DateTime.Now;
    }

    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public Queue<DomainEvent> GeneratedEvents { get; } = new(); // todo: change to internal?

    protected void AddEvent(DomainEvent @event)
    {
        GeneratedEvents.Enqueue(@event);
    }
}