using MediatR;
using CqrsNinja.Contracts.DTO;
using CqrsNinja.Contracts.Data;
using CqrsNinja.Core.Exceptions;
using AutoMapper;

namespace CqrsNinja.Providers.Handlers.Queries
{
    public class GetNinjaByIdQuery : IRequest<NinjaDTO>
    {
        public int NinjaId { get; }
        public GetNinjaByIdQuery(int ninjaId)
        {
            NinjaId = ninjaId;
        }
    }

    public class GetNinjaByIdQueryHandler : IRequestHandler<GetNinjaByIdQuery, NinjaDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetNinjaByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NinjaDTO> Handle(GetNinjaByIdQuery request, CancellationToken cancellationToken)
        {
            var ninja = await Task.FromResult(_repository.Ninjas.Get(request.NinjaId));

            if (ninja == null)
            {
                throw new EntityNotFoundException($"No Ninja found for Id {request.NinjaId}");
            }

            return _mapper.Map<NinjaDTO>(ninja);
        }
    }
}