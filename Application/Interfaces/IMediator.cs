namespace Framework.Application.Interfaces;

public interface IMediator
{
    public void RegisterBehaviour(Behaviour behaviour);

    public Task EmitEvent(dynamic @event);
}