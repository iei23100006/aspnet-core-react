using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Undelete[FTName]
{
    public sealed class Undelete[FTName]Handler : IRequestHandler<Undelete[FTName]Request, Get[FTName]Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly I[FTName]Repository _[FTName | camelcase]Repository;
        private readonly IMapper _mapper;

        public Undelete[FTName]Handler(IUnitOfWork unitOfWork, I[FTName]Repository [FTName | camelcase]Repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _[FTName | camelcase]Repository = [FTName | camelcase]Repository;
            _mapper = mapper;
        }

        public async Task<Get[FTName]Response> Handle(Undelete[FTName]Request request, CancellationToken cancellationToken)
        {
            // Get [FTName]
            var [FTName | camelcase] = await _[FTName | camelcase]Repository.GetAsync(request.Id, cancellationToken);
            if ([FTName | camelcase] == null)
            {
               throw new Exception($"[FTName] with {request.Id} not found!"); 
            }

            // Update [FTName | camelcase] to be active
            _[FTName | camelcase]Repository.Undelete([FTName | camelcase], request.UpdatedById, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            // Map the [FTName | camelcase] to the response
            return _mapper.Map<Get[FTName]Response>([FTName | camelcase]);
        }
    }
}

