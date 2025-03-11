using MediatR;


namespace ASPReactCQRS.Application.Features.UserFeatures.GetUser
{
    public sealed record GetUserRequest(string Id) : IRequest<GetUserResponse>;
}
