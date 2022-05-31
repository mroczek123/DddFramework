using Framework.Domain;

namespace Framework.Application.Interfaces;

public interface IStorageProvider
{
    public IQueryable<TEntity> Objects<TEntity>() where TEntity : Entity;
    public IQueryable<TEntity> ReadOnlyObjects<TEntity>() where TEntity : Entity;
    public TEntity Add<TEntity>(TEntity entity) where TEntity : Entity;
    public void Update<TEntity>(TEntity entity) where TEntity : Entity;
    public void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    public void Commit();
}