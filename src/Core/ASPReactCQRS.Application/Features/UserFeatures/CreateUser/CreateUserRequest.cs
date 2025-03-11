using MediatR;

namespace ASPReactCQRS.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserRequest(string Id, 
    string Name, 
    string? Email, 
    string? VendorCode,
    string? Company) : IRequest<CreateUserResponse>;
}
