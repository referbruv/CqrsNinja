using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Repositories;
using ReadersCqrsApp.Providers.Requests.Queries;

namespace ReadersCqrsApp.Providers.Handlers.Queries
{
    public class GetSingleReaderQueryHandler : IRequestHandler<GetSingleReaderQueryRequest, ReaderResponseModel>
    {
        private readonly IReadersRepository repository;

        public GetSingleReaderQueryHandler(IReadersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ReaderResponseModel> Handle(GetSingleReaderQueryRequest request, CancellationToken cancellationToken)
        {
            var reader = this.repository.GetSingle(request.ReaderId);

            if (reader != null)
            {
                return new ReaderResponseModel
                {
                    Id = reader.Id,
                    Alias = reader.Alias,
                    Bio = reader.Bio,
                    EmailAddress = reader.User.EmailAddress,
                    Username = reader.User.Username
                };
            }
            
            return new ReaderResponseModel();
        }
    }
}