namespace Framework.Domain;

public abstract class SimpleValue<T> where T : IEquatable<T>
{
    protected SimpleValue(T value)
    {
        Value = value;
    }

    public T Value { get; }


    public static bool operator ==(SimpleValue<T> one, SimpleValue<T> other)
    {
        return one.Value.Equals(other.Value);
    }

    public static bool operator !=(SimpleValue<T> one, SimpleValue<T> other)
    {
        return one.Value.Equals(other.Value);
    }

    protected bool Equals(SimpleValue<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SimpleValue<T>) obj);
    }
}