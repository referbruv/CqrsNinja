using System.Collections;
using System.Collections.Generic;
using MediatR;
using ReadersCqrsApp.Models;

namespace ReadersCqrsApp.Providers.Requests.Queries
{
    public class GetAllReadersQueryRequest : IRequest<IEnumerable<ReaderResponseModel>>
    { }
}