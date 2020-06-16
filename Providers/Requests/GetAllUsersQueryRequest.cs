using System.Collections.Generic;
using MediatR;
using ReadersCqrsApp.Models;

namespace ReadersCqrsApp.Providers.Requests.Queries
{
    public class GetAllUsersQueryRequest : IRequest<IEnumerable<UserResponseModel>>
    {
    }
}