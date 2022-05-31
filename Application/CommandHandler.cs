namespace Framework.Application;

public abstract class CommandHandler
{
}

public abstract class CommandHandler<TC> : CommandHandler
{
    protected UnitOfWork UnitOfWork;

    public CommandHandler(UnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public abstract Task<object> Handle(TC command);
}