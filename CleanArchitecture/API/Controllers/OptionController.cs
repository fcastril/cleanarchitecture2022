using Application.DTO;
using Application.Features.Options.Commands.CreateOpion;
using Application.Features.Options.Commands.DeleteOption;
using Application.Features.Options.Commands.UpdateOption;
using Application.Features.Options.Queries.GetAllOption;
using Application.Features.Options.Queries.GetOptionByCode;
using Application.Features.Options.Queries.GetOptionById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "All")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(IEnumerable<OptionDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OptionDto>>> GetOptionAll()
        {
            var query = new GetAllOptionQuery();
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("ByCode/{code}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(OptionDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OptionDto>> GetOptionByCode(string code)
        {
            var query = new GetOptionByCodeQuery(code);
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("ById/{Id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(OptionDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OptionDto>> GetOptionById(Guid Id)
        {
            var query = new GetOptionByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "CreateOption")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateOption([FromBody] CreateOptionCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateOption")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Guid>> UpdateOption([FromBody] UpdateOptionCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete("{id}", Name = "DeleteOption")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeleteOption(Guid id)
        {
            var command = new DeleteOptionCommand
            {
                Id = id
            };


            await _mediator.Send(command);

            return NoContent();
        }

    }
}
