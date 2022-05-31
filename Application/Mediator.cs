using Framework.Application.Interfaces;

namespace Framework.Application;

public class Mediator : IMediator
{
    /// <summary>
    ///     Maps DomainEvent Types to Behaviour instances.
    /// </summary>
    private readonly Dictionary<Type, HashSet<Behaviour>> _eventSubscribers = new();

    public void RegisterBehaviour(Behaviour behaviour)
    {
        var eventType = behaviour.GetType().BaseType.GenericTypeArguments[0];
        if (!_eventSubscribers.ContainsKey(eventType)) _eventSubscribers.Add(eventType, new HashSet<Behaviour>());
        _eventSubscribers[eventType].Add(behaviour);
    }

    /// <summary>
    ///     todo: do something with exception handling. It should be handled but probably should not destroy whole app
    /// </summary>
    public async Task EmitEvent(dynamic @event)
    {
        HashSet<Behaviour>? handlers;
        if (!_eventSubscribers.TryGetValue(@event.GetType(), out handlers)) return;
        foreach (dynamic handler in handlers)
            await handler.Execute(@event);
    }
}