using MediatR;
using ReadersCqrsApp.Models;

namespace ReadersCqrsApp.Providers.Requests.Commands
{
    public class CreateReaderCommandRequest : IRequest<int>
    {
        public CreateReaderModel Model { get; }
        public CreateReaderCommandRequest(CreateReaderModel model)
        {
            this.Model = model;
        }
    }
}