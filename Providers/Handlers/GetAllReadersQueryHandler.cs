using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Repositories;
using ReadersCqrsApp.Providers.Requests.Queries;

namespace ReadersCqrsApp.Providers.Handlers.Queries
{
    public class GetAllReadersQueryHandler : IRequestHandler<GetAllReadersQueryRequest, IEnumerable<ReaderResponseModel>>
    {
        private readonly IReadersRepository repository;

        public GetAllReadersQueryHandler(IReadersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ReaderResponseModel>> Handle(GetAllReadersQueryRequest request, CancellationToken cancellationToken)
        {
            var readers = this.repository.GetAll();
            return readers.Select(x => new ReaderResponseModel
            {
                Id = x.Id,
                Alias = x.Alias,
                EmailAddress = x.User.EmailAddress,
                Username = x.User.Username,
                Bio = x.Bio
            });
        }
    }
}