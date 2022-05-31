namespace Framework.Domain;

/// <summary>
///     If you get No suitable constructor was found for entity type 'X'. Add empty internal SomeConstructor(){}
///     Remember that child class must also recod class
/// </summary>
public abstract class Value : Validable
{
#pragma warning disable IDE0051 // efcore workaround
    private Guid? Id { get; }
#pragma warning restore IDE0051

    protected abstract bool Equals(Value other);

    public static bool operator ==(Value one, Value other)
    {
        return one.Equals(other);
    }

    public static bool operator !=(Value one, Value other)
    {
        return !one.Equals(other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Value) obj);
    }
}