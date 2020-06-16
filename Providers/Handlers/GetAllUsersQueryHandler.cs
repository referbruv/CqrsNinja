using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Repositories;
using ReadersCqrsApp.Providers.Requests.Queries;

namespace ReadersCqrsApp.Providers.Handlers.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, IEnumerable<UserResponseModel>>
    {
        private readonly IUsersRepository repository;

        public GetAllUsersQueryHandler(IUsersRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<UserResponseModel>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var response = this.repository.GetAll();
            return response;
        }
    }
}