namespace Framework.Domain;

public abstract class EntityEvent<T> : DomainEvent where T : Entity
{
    public readonly T Entity;

    public EntityEvent(T entity)
    {
        Entity = entity;
    }
}