using Framework.Application.Interfaces;
using Framework.Domain;

namespace Framework.Application;

public class UnitOfWork
{
    private readonly Queue<DomainEvent> _eventsQueue = new();
    private readonly IMediator _mediator;
    private readonly IStorageProvider _storageProvider;

    public UnitOfWork(IMediator mediator, IStorageProvider storageProvider)
    {
        _mediator = mediator;
        _storageProvider = storageProvider;
    }

    public async void Commit()
    {
        _storageProvider.Commit();
        DomainEvent domainEvent;
        while (_eventsQueue.TryDequeue(out domainEvent)) await _mediator.EmitEvent(domainEvent);
    }

    public TRepository GetRepository<TRepository>()
    {
        var constructor = typeof(TRepository)
            .GetConstructor(new[] {typeof(UnitOfWork)});

        return (TRepository) typeof(TRepository)
            .GetConstructor(new[] {typeof(UnitOfWork)})
            .Invoke(new object[] {this});
    }

    internal T Add<T>(T entity) where T : Entity
    {
        foreach (var @event in entity.GeneratedEvents)
            _eventsQueue.Enqueue(@event);
        return _storageProvider.Add(entity);
    }

    internal void Update<T>(T entity) where T : Entity
    {
        foreach (var @event in entity.GeneratedEvents)
            _eventsQueue.Enqueue(@event);
        _storageProvider.Update(entity);
    }

    internal void Delete<T>(T entity) where T : Entity
    {
        foreach (var @event in entity.GeneratedEvents)
            _eventsQueue.Enqueue(@event);
        _storageProvider.Delete(entity);
    }

    internal IQueryable<T> Objects<T>() where T : Entity
    {
        return _storageProvider.Objects<T>();
    }

    internal IQueryable<T> ReadOnlyObjects<T>() where T : Entity
    {
        return _storageProvider.ReadOnlyObjects<T>();
    }
}