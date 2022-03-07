using Football.Api.Features.Account;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await _mediatr.Send(command);

            return Ok(response);
        }
    }
}
