using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Repositories;
using ReadersCqrsApp.Providers.Requests.Commands;

namespace ReadersCqrsApp.Providers.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, int>
    {
        private readonly IUsersRepository repository;

        public CreateUserCommandHandler(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await repository.CreateUser(request.Model);
            return response;
        }
    }
}