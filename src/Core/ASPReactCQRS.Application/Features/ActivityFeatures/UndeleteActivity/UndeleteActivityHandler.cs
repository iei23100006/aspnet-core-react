using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UndeleteActivity
{
    public sealed class UndeleteActivityHandler : IRequestHandler<UndeleteActivityRequest, GetActivityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public UndeleteActivityHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivityResponse> Handle(UndeleteActivityRequest request, CancellationToken cancellationToken)
        {
            // Get Activity
            var activity = await _activityRepository.GetAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                throw new Exception($"[FTName] with {request.Id} not found!"); 
            }

            // Update activity to be active
            _activityRepository.Undelete(activity, request.UpdatedById, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            // Map the activity to the response
            return _mapper.Map<GetActivityResponse>(activity);
        }
    }
}

