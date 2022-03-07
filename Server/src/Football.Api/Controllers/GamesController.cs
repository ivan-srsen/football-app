using Football.Api.Features.Games;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("preview")]
        public async Task<IActionResult> GetPreview([FromQuery] GamePreviewQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task Post([FromBody] GameCreateCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
