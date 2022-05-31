using Framework.Domain;

namespace Framework.Application;

public abstract class Behaviour
{
}

public abstract class Behaviour<TEvent> : Behaviour where TEvent : DomainEvent
{
    public abstract Task Execute(TEvent @event);
}