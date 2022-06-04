using Framework.Domain;

namespace Framework.Application;

public interface IQuery<T>
{
    public IEnumerable<T> Execute();
}