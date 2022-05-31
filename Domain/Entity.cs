namespace Framework.Domain;

/// <summary>
///     If you get No suitable constructor was found for entity type 'X'. Add empty internal SomeConstructor(){}
/// </summary>
public abstract class Entity : Validable
{
    public Entity(DateTime? createdAt = null)
    {
        CreatedAt = createdAt != null ? (DateTime) createdAt : DateTime.Now;
    }

    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public Queue<DomainEvent> GeneratedEvents { get; } = new(); // todo: change to internal?

    protected void AddEvent(DomainEvent @event)
    {
        ValidateFull();
        GeneratedEvents.Enqueue(@event);
    }
}