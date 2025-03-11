using MediatR;

namespace ASPReactCQRS.Application.Abstractions.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
