using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity
{
    public sealed class GetActivityHandler : IRequestHandler<GetActivityRequest, GetActivityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public GetActivityHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivityResponse> Handle(GetActivityRequest request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                throw new Exception("Activity not found");
            }

            var response = _mapper.Map<GetActivityResponse>(activity);

            return response;
        }
    }
}
