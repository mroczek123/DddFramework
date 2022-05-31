using System.Reflection;
using Framework.Common.Extensions.TypeExtensions;

namespace Framework.Domain;

public abstract class Validable
{
    public virtual void ValidateFull()
    {
        ValidateProperties();
        ValidateSelf();
    }

    /// <exception cref="DomainException"></exception>
    public virtual void ValidateSelf()
    {
    }

    public void ValidateProperties()
    {
        GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(t => typeof(Validable).IsAssignableFrom(t.PropertyType))
            .ToList()
            .ForEach(propInfo =>
            {
                var property = propInfo.GetValue(this);
                if (property == null)
                {
                    throw new Exception($"{this} does not have initialized property {propInfo.Name}!");
                }
                propInfo.PropertyType.InvokeObjectMethod(property, "ValidateFull");
            });
    }
}