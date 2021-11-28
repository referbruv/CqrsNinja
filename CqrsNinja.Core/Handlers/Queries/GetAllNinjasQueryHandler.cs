using AutoMapper;
using CqrsNinja.Contracts.Data;
using CqrsNinja.Contracts.Data.Entities;
using CqrsNinja.Contracts.DTO;
using MediatR;
using System.Linq;

namespace CqrsNinja.Providers.Handlers.Queries
{
    public class GetAllNinjasQuery : IRequest<IEnumerable<NinjaDTO>>
    {
    }

    public class GetAllNinjasQueryHandler : IRequestHandler<GetAllNinjasQuery, IEnumerable<NinjaDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllNinjasQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NinjaDTO>> Handle(GetAllNinjasQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Ninjas.GetAll());
            return _mapper.Map<IEnumerable<NinjaDTO>>(entities);
        }
    }
}