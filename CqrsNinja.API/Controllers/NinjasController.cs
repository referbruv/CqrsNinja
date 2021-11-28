using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CqrsNinja.Contracts.DTO;
using CqrsNinja.Core.Exceptions;
using CqrsNinja.Providers.Handlers.Commands;
using CqrsNinja.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsNinja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NinjasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NinjaDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllNinjasQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateNinjaDTO model)
        {
            try
            {
                var command = new CreateNinjaCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(NinjaDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetNinjaByIdQuery(id);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }
    }
}