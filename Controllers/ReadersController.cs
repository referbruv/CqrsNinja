using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Requests.Commands;
using ReadersCqrsApp.Providers.Requests.Queries;

namespace ReadersCqrsApp.Controllers
{
    public interface IReadersController
    {
        Task<IEnumerable<ReaderResponseModel>> Get();
        Task<ReaderResponseModel> GetSingle(int id);
        Task<int> Post(CreateReaderModel model);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase, IReadersController
    {
        private readonly IMediator mediator;

        public ReadersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ReaderResponseModel>> Get()
        {
            var query = new GetAllReadersQueryRequest();
            var response = await mediator.Send(query);
            return response;
        }

        [HttpPost]
        public async Task<int> Post(CreateReaderModel model)
        {
            var command = new CreateReaderCommandRequest(model);
            var response = await mediator.Send(command);
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ReaderResponseModel> GetSingle(int id)
        {
            var query = new GetSingleReaderQueryRequest(id);
            var response = await mediator.Send(query);
            return response;
        }
    }
}