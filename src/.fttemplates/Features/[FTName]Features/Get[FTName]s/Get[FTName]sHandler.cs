using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using MediatR;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s
{
    public sealed class Get[FTName]sHandler : IRequestHandler<Get[FTName]sRequest, Get[FTName]sResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly I[FTName]Repository _[FTName | camelcase]Repository;
        private readonly IMapper _mapper;

        public Get[FTName]sHandler(IUnitOfWork unitOfWork, I[FTName]Repository [FTName | camelcase]Repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _[FTName | camelcase]Repository = [FTName | camelcase]Repository;
            _mapper = mapper;
        }

        public async Task<Get[FTName]sResponse> Handle(Get[FTName]sRequest request, CancellationToken cancellationToken)
        {
            var ([FTName | camelcase]s, total) = await _[FTName | camelcase]Repository.Get[FTName]s(request.PageIndex, request.PageSize, request.IsActive, cancellationToken);

            var response = _mapper.Map<Get[FTName]sResponse>([FTName | camelcase]s);

            
            // Map the pagination
            response.PageIndex = request.PageIndex;
            response.PageSize = request.PageSize;
            response.TotalRows = total;

            return response;
        }
    }
}
