using Framework.Domain;

namespace Framework.Application;

public abstract class Repository<T> where T : AggregateRoot
{
    private readonly UnitOfWork _unitOfWork;

    public Repository(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IQueryable<T> Objects => _unitOfWork.Objects<T>();

    public IQueryable<T> ReadOnlyObjects => _unitOfWork.ReadOnlyObjects<T>();

    public T Add(T entity)
    {
        return _unitOfWork.Add(entity);
    }

    public void Update(T entity)
    {
        _unitOfWork.Update(entity);
    }

    public void Delete(T entity)
    {
        _unitOfWork.Delete(entity);
    }
}