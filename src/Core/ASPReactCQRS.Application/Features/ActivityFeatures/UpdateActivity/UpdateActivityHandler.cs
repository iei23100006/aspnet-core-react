using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UpdateActivity
{
    public sealed class UpdateActivityHandler : IRequestHandler<UpdateActivityRequest, GetActivityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public UpdateActivityHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivityResponse> Handle(UpdateActivityRequest request, CancellationToken cancellationToken)
        {
            var activityBody = request.ActivityBody;

            // Get existing Activity
            var existingActivity = await _activityRepository.GetAsync(activityBody.Id, cancellationToken);            
            if (existingActivity == null)
            {
                throw new Exception($"Activity with {activityBody.Id} not found!");
            } 

            // Map Request to Activity
            _mapper.Map(activityBody, existingActivity);
            
            _activityRepository.Update(existingActivity, request.UpdatedById, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);


            // Map the updated Activity to the response
            return _mapper.Map<GetActivityResponse>(existingActivity);
        }
    }
}
