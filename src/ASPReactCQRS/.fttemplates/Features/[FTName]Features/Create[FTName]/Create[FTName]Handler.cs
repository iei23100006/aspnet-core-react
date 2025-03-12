using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Create[FTName]
{
    public sealed class Create[FTName]Handler : IRequestHandler<Create[FTName]Request, Get[FTName]Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly I[FTName]Repository _[FTName | camelcase]Repository;
        private readonly IMapper _mapper;

        public Create[FTName]Handler(IUnitOfWork unitOfWork, I[FTName]Repository [FTName | camelcase]Repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _[FTName | camelcase]Repository = [FTName | camelcase]Repository;
            _mapper = mapper;
        }

        public async Task<Get[FTName]Response> Handle(Create[FTName]Request request, CancellationToken cancellationToken)
        {
            // Check if [FTName] Name already exist
            var existing[FTName] = await _[FTName | camelcase]Repository.Get[FTName]ByName(request.[FTName]Name, cancellationToken);
            if (existing[FTName] != null)
            {
                throw new Exception("[FTName] Name already exist");
            }

            // Create [FTName] Object
            var [FTName | camelcase] = _mapper.Map<[FTName]>(request);

            // Save [FTName]
            await _[FTName | camelcase]Repository.CreateAsync([FTName | camelcase], cancellationToken, request.CreatedById);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<Get[FTName]Response>([FTName | camelcase]); 
        }
    }
}
