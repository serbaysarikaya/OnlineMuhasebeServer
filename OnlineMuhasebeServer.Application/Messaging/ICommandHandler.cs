using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    internal interface ICommandHandler<in TCommand, TResponse> :
        IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
