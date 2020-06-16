using MediatR;
using ReadersCqrsApp.Models;

namespace ReadersCqrsApp.Providers.Requests.Queries
{
    public class GetSingleReaderQueryRequest : IRequest<ReaderResponseModel>
    {
        public int ReaderId { get; }
        public GetSingleReaderQueryRequest(int readerId)
        {
            ReaderId = readerId;
        }
    }
}
