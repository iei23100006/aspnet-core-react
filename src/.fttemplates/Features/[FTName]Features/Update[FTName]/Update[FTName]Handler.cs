using AutoMapper;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Update[FTName]
{
    public sealed class Update[FTName]Handler : IRequestHandler<Update[FTName]Request, Get[FTName]Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly I[FTName]Repository _[FTName | camelcase]Repository;
        private readonly IMapper _mapper;

        public Update[FTName]Handler(IUnitOfWork unitOfWork, I[FTName]Repository [FTName | camelcase]Repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _[FTName | camelcase]Repository = [FTName | camelcase]Repository;
            _mapper = mapper;
        }

        public async Task<Get[FTName]Response> Handle(Update[FTName]Request request, CancellationToken cancellationToken)
        {
            var [FTName | camelcase]Body = request.[FTName]Body;

            // Get existing [FTName]
            var existing[FTName] = await _[FTName | camelcase]Repository.GetAsync([FTName | camelcase]Body.Id, cancellationToken);            
            if (existing[FTName] == null)
            {
                throw new Exception($"[FTName] with {[FTName | camelcase]Body.Id} not found!");
            } 

            // Map Request to [FTName]
            _mapper.Map([FTName | camelcase]Body, existing[FTName]);
            
            _[FTName | camelcase]Repository.Update(existing[FTName], request.UpdatedById, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);


            // Map the updated [FTName] to the response
            return _mapper.Map<Get[FTName]Response>(existing[FTName]);
        }
    }
}
