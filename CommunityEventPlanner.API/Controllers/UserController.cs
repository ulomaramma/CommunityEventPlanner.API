using CommunityEventPlanner.Application.UseCases.Users.Command.GoogleSignIn;
using CommunityEventPlanner.Application.UseCases.Users.Command.LoginUser;
using CommunityEventPlanner.Application.UseCases.Users.Command.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityEventPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.Code, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.Code, response);
        }

        [HttpPost("google-signin")]
        public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.Code, response);
        }
    }
}
