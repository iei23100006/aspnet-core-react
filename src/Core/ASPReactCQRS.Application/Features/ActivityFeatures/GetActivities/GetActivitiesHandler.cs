using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using MediatR;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities
{
    public sealed class GetActivitiesHandler : IRequestHandler<GetActivitiesRequest, GetActivitiesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public GetActivitiesHandler(IUnitOfWork unitOfWork, IActivityRepository activityRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<GetActivitiesResponse> Handle(GetActivitiesRequest request, CancellationToken cancellationToken)
        {
            var (Activities, total) = await _activityRepository.GetActivities(request.PageIndex, request.PageSize, request.IsActive, cancellationToken);

            var response = _mapper.Map<GetActivitiesResponse>(Activities);

            
            // Map the pagination
            response.PageIndex = request.PageIndex;
            response.PageSize = request.PageSize;
            response.TotalRows = total;

            return response;
        }
    }
}
