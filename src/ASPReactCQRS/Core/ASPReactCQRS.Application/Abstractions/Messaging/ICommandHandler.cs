﻿using MediatR;

namespace ASPReactCQRS.Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
       where TCommand : ICommand<TResponse>
    {
    }
}
