using Application.Models.common;
using Application.Modules.AccountModule.Commands.EmailConfirmCommand;
using Application.Modules.AccountModule.Commands.RefreshTokenCommand;
using Application.Modules.AccountModule.Commands.SignInCommand;
using Application.Modules.AccountModule.Commands.SignUpCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Middleware;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        [Transaction]
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("email-confirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] SignupConfirmRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }

        [Transaction]
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }

        //[Transaction]
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromHeader] RefreshTokenRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
    }
}
