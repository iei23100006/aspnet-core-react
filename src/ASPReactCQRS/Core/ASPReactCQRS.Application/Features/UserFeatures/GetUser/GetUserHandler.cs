using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;

namespace ASPReactCQRS.Application.Features.UserFeatures.GetUser
{
    public sealed class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetUserResponse>(user);
        }
    }
}
