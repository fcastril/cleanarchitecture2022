using CleanArchitecture.Application.Features.Options.Commands.CreateOpion;
using CleanArchitecture.Application.Features.Options.Commands.DeleteOption;
using CleanArchitecture.Application.Features.Options.Commands.UpdateOption;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
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

        [HttpPost(Name = "CreateOption")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateOption([FromBody] CreateOptionCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateOption")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> UpdateOption([FromBody] UpdateOptionCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete("{id}", Name = "DeleteOption")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
