using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Providers.Requests.Commands;
using ReadersCqrsApp.Providers.Requests.Queries;

namespace ReadersCqrsApp.Controllers
{
    public interface IUsersController
    {
        Task<IEnumerable<UserResponseModel>> Get();
        Task<int> Post([FromBody] UserRequestModel model);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase, IUsersController
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] UserRequestModel model)
        {
            var command = new CreateUserCommandRequest(model);
            var response = await mediator.Send(command);
            return response;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponseModel>> Get()
        {
            var query = new GetAllUsersQueryRequest();
            var response = await mediator.Send(query);
            return response;
        }
    }
}