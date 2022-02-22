using Football.Api.Features.Registrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AccountsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationCommand command)
        {
            await _mediatr.Send(command);

            return Ok();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
