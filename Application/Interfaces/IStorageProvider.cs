using Framework.Domain;

namespace Framework.Application.Interfaces;

public interface IStorageProvider
{
    public IQueryable<TAggregateRoot> Objects<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
    public IQueryable<TAggregateRoot> ReadOnlyObjects<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
    public TAggregateRoot Add<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
    public void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
    public void Delete<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : AggregateRoot;
    public void Commit();
}