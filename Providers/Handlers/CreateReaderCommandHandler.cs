using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReadersCqrsApp.Providers.Repositories;
using ReadersCqrsApp.Providers.Requests.Commands;

namespace ReadersCqrsApp.Providers.Handlers.Commands
{
    public class CreateReaderCommandHandler : IRequestHandler<CreateReaderCommandRequest, int>
    {
        private readonly IReadersRepository repository;

        public CreateReaderCommandHandler(IReadersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateReaderCommandRequest request, CancellationToken cancellationToken)
        {
            var readerId = await this.repository.CreateReader(request.Model);
            return readerId;
        }
    }
}