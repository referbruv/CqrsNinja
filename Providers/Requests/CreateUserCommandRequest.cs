using MediatR;
using ReadersCqrsApp.Models;

namespace ReadersCqrsApp.Providers.Requests.Commands
{
    public class CreateUserCommandRequest : IRequest<int>
    {
        public UserRequestModel Model { get; }

        public CreateUserCommandRequest(UserRequestModel model)
        {
            this.Model = model;
        }
    }
}