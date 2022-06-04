namespace Framework.Domain;

/// <summary>
///     If you get No suitable constructor was found for entity type 'X'. Add empty internal SomeConstructor(){}
/// </summary>
public abstract class Entity
{
#pragma warning disable IDE0051 // efcore workaround
    private Guid? Id { get; }
#pragma warning restore IDE0051

    protected abstract bool Equals(Entity other);

    public static bool operator ==(Entity one, Entity other)
    {
        return one.Equals(other);
    }

    public static bool operator !=(Entity one, Entity other)
    {
        return !one.Equals(other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Entity) obj);
    }
}