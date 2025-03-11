using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.DeleteActivity
{
    public sealed class DeleteActivityHandler : IRequestHandler<DeleteActivityRequest, GetActivityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public DeleteActivityHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivityResponse> Handle(DeleteActivityRequest request, CancellationToken cancellationToken)
        {
            // Get existing activity
            var activity = await _activityRepository.GetAsync(request.Id, cancellationToken);
            if (activity == null)
            {
                throw new Exception("Activity not found");
            }

            // Update activity to be deleted
            _activityRepository.Delete(activity, request.DeletedById, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            // Map the deleted activity to the response
            return _mapper.Map<GetActivityResponse>(activity);
        }
    }
}
