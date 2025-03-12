using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]
{
    public sealed class Get[FTName]Handler : IRequestHandler<Get[FTName]Request, Get[FTName]Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly I[FTName]Repository _[FTName | camelcase]Repository;
        private readonly IMapper _mapper;
        public Get[FTName]Handler(IUnitOfWork unitOfWork, I[FTName]Repository [FTName | camelcase]Repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _[FTName | camelcase]Repository = [FTName | camelcase]Repository;
            _mapper = mapper;
        }

        public async Task<Get[FTName]Response> Handle(Get[FTName]Request request, CancellationToken cancellationToken)
        {
            var [FTName | camelcase] = await _[FTName | camelcase]Repository.GetAsync(request.Id, cancellationToken);
            if ([FTName | camelcase] == null)
            {
                throw new Exception($"[FTName] with {request.Id} not found!"); 
            }

            var response = _mapper.Map<Get[FTName]Response>([FTName | camelcase]);

            return response;
        }
    }
}
