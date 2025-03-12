using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.CreateActivity
{
    public sealed class CreateActivityHandler : IRequestHandler<CreateActivityRequest, GetActivityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public CreateActivityHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivityResponse> Handle(CreateActivityRequest request, CancellationToken cancellationToken)
        {
            // Check if Activity Name already exist
            var existingActivity = await _activityRepository.GetActivityByName(request.ActivityName, cancellationToken);
            if (existingActivity != null)
            {
                throw new Exception("Activity Name already exist");
            }

            // Create Activity Object
            var activity = _mapper.Map<Activity>(request);

            // Save Activity
            await _activityRepository.CreateAsync(activity, cancellationToken, request.CreatedById);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<GetActivityResponse>(activity); 
        }
    }
}
